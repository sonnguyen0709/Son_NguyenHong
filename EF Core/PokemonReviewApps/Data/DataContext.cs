using Microsoft.EntityFrameworkCore;
using PokemonReviewApps.Models;
using System.Security.Claims;

namespace PokemonReviewApps.Data
{
    public class DataContext : DbContext
    {
        // Stores a reference to the HTTP context accessor
        // Can access the current HTTP request’s user information (like username) inside SaveChanges().
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Each DbSet<T> represents a database table for entity T
        // Example: DbSet<Pokemon> means EF Core will manage the Pokemons table
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<PokemonSpecies> PokemonSpecies { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        // Overrides EF Core’s default SaveChanges() method to add audit tracking
        // Automatically filling in CreatedBy, CreatedAt, ModifiedBy, ModifiedAt).
        public override int SaveChanges()
        {
            // Tries to get the logged-in username from the HTTP context’s claims.
            // If no user is logged in, defaults to "System"
            string username = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value ?? "System";

            // Gets all tracked entities in the current change tracker
            // Filters to only those that inherit from BaseEntity and are either newly added or modified
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity &&
                (e.State == EntityState.Added || e.State == EntityState.Modified));

            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime vnNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnTimeZone);
            // Loops through each matching entry
            foreach (var entityEntry in entries)
            {
                // Casts it to BaseEntity so we can access audit properties
                var entity = (BaseEntity)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    // If the entity is new Added : Sets CreatedAt to the current UTC time, sets CreatedBy to the username, or "System" if empty
                    entity.CreatedAt = vnNow;
                    entity.CreatedBy = string.IsNullOrWhiteSpace(username) ? "System" : username;
                }

                else
                {
                    // Same as Created
                    entity.ModifiedBy = string.IsNullOrWhiteSpace(username) ? "System" : username;
                    entity.ModifiedAt = vnNow;
                }
            }
            return base.SaveChanges();
        }

        // Using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary key : {PokemonSpeciesId, CategoryId}
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonSpeciesId, pc.CategoryId });

            // Defines many-to-one relationship: PokemonCategory → PokemonSpecies
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pc => pc.PokemonSpecies)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.PokemonSpeciesId)
                .OnDelete(DeleteBehavior.Cascade);
            // Same as above, but PokemonCategory → Category
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(po => po.Pokemon)
                .WithMany(p => p.PokemonOwners)
                .HasForeignKey(po => po.PokemonId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(po => po.Owner)
                .WithMany(o => o.PokemonOwners)
                .HasForeignKey(po => po.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
