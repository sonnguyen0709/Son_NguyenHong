using Microsoft.EntityFrameworkCore;
using PokemonReviewApps.Dto;
using PokemonReviewApps.Models;
using PokemonReviewApps.Data;
using PokemonReviewApps.Interface;
using PokemonReviewApps.Request;
using Microsoft.AspNetCore.Http.HttpResults;
namespace PokemonReviewApps.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly DataContext _context;
        public PokemonService(DataContext context)
        {
            _context = context;
        }
        public ICollection<PokemonDto> GetAllPokemons()
        {
            // Loads all Pokemon records from the database
            var pokemons = _context.Pokemons
            // .Include(...) loads related navigation properties (PokemonOwners)
            .Include(p => p.PokemonOwners)
            // ThenInclude: Load each Owner for the PokemonOwner relation, load the Country for each Owner
            .ThenInclude(po => po.Owner)
            .ThenInclude(o => o.Country)
            .OrderBy(p => p.Id)
            .ToList();

            return pokemons.Select(p => new PokemonDto
            {
                Id = p.Id,
                Nickname = p.Nickname,
                BirthDate = p.BirthDate,
                PokemonSpecies = _context.PokemonSpecies
                .Where(s => s.Id == p.PokemonSpeciesId)
                .Select(s => s.Name)
                .SingleOrDefault() ?? string.Empty,

                Owners = p.PokemonOwners.Any()
                ? p.PokemonOwners.Select(po => new OwnerDto
                {
                    Id = po.Owner.Id,
                    FirstName = po.Owner.FirstName,
                    LastName = po.Owner.LastName,
                    Gym = po.Owner.Gym,
                    Country = new CountryDto
                    {
                        Id = po.Owner.Country.Id,
                        Name = po.Owner.Country.Name
                    }
                }).ToList() : null,

                // Same as Owners
                Categories = _context.PokemonCategories
                .Where(pc => pc.PokemonSpeciesId == p.PokemonSpeciesId)
                .Any()
                ? _context.PokemonCategories
                .Where(pc => pc.PokemonSpeciesId == p.PokemonSpeciesId)
                .Select(pc => new CategoryDto
                {
                    Id = pc.Category.Id,
                    Name = pc.Category.Name
                }).ToList() : null
            }).ToList();
        }
        public PokemonDto? GetPokemonById(int id)
        {
            var pokemon = _context.Pokemons
            .Include(p => p.PokemonOwners)
            .ThenInclude(po => po.Owner)
            .ThenInclude(o => o.Country)
            .SingleOrDefault(p => p.Id == id);

            if (pokemon == null)
                return null;

            return new PokemonDto
            {
                Id = pokemon.Id,
                Nickname = pokemon.Nickname,
                BirthDate = pokemon.BirthDate,
                PokemonSpecies = _context.PokemonSpecies
                .Where(s => s.Id == pokemon.PokemonSpeciesId)
                .Select(s => s.Name)
                .SingleOrDefault() ?? string.Empty,

                Owners = pokemon.PokemonOwners.Any()
                ? pokemon.PokemonOwners
                .Select(po => new OwnerDto
                {
                    Id = po.Owner.Id,
                    FirstName = po.Owner.FirstName,
                    LastName = po.Owner.LastName,
                    Gym = po.Owner.Gym,
                    Country = new CountryDto
                    {
                        Id = po.Owner.Country.Id,
                        Name = po.Owner.Country.Name
                    }
                }).ToList() : null,

                Categories = _context.PokemonCategories
                    .Where(pc => pc.PokemonSpeciesId == pokemon.PokemonSpeciesId)
                    .Any()
                    ? _context.PokemonCategories
                    .Where(pc => pc.PokemonSpeciesId == pokemon.PokemonSpeciesId)
                    .Select(pc => new CategoryDto
                    {
                        Id = pc.CategoryId,
                        Name = pc.Category.Name
                    }).ToList() : null
            };
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        public bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(p => p.Id == id);
        }
        public bool CreatePokemon(PokemonCreatedRequest request)
        {
            var pokemon = new Pokemon
            {
                Nickname = request.Nickname,
                BirthDate = request.BirthDate,
                PokemonSpeciesId = request.PokemonSpeciesId,
            };

            _context.Pokemons.Add(pokemon);
            Save();

            if (request.OwnerIds != null && request.OwnerIds.Any())
            {
                foreach (var ownerId in request.OwnerIds)
                {
                    _context.PokemonOwners.Add(new PokemonOwner
                    {
                        PokemonId = pokemon.Id,
                        OwnerId = ownerId
                    });
                }
            }

            if (request.CategoryIds != null && request.CategoryIds.Any())
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    _context.PokemonCategories.Add(new PokemonCategory
                    {
                        PokemonSpeciesId = request.PokemonSpeciesId,
                        CategoryId = categoryId
                    });
                }
            }

            return Save();
        }

        public bool UpdatePokemon(int id, PokemonUpdatedRequest request)
        {
            var existingPokemon = _context.Pokemons
                .Include(p => p.PokemonOwners)
                .SingleOrDefault(p => p.Id == id);

            if (existingPokemon == null)
                return false;

            existingPokemon.Nickname = request.Nickname;
            existingPokemon.BirthDate = request.BirthDate;
            existingPokemon.PokemonSpeciesId = request.PokemonSpeciesId;

            _context.PokemonOwners.RemoveRange(existingPokemon.PokemonOwners);

            if (request.OwnerIds != null && request.OwnerIds.Any())
            {
                foreach (var ownerId in request.OwnerIds)
                {
                    _context.PokemonOwners.Add(new PokemonOwner
                    {
                        PokemonId = id,
                        OwnerId = ownerId
                    });
                }
            }

            var speciesCategories = _context.PokemonCategories
                .Where(pc => pc.PokemonSpeciesId == request.PokemonSpeciesId);
            _context.PokemonCategories.RemoveRange(speciesCategories);

            if (request.CategoryIds != null && request.CategoryIds.Any())
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    _context.PokemonCategories.Add(new PokemonCategory
                    {
                        PokemonSpeciesId = request.PokemonSpeciesId,
                        CategoryId = categoryId
                    });
                }
            }

            return Save();
        }
        public bool DeletePokemon(int id)
        {
            var pokemon = _context.Pokemons
                .Include(p => p.PokemonOwners)
                .SingleOrDefault(p => p.Id == id);

            if (pokemon == null)
                return false;

            if (pokemon.PokemonOwners.Any())
                _context.PokemonOwners.RemoveRange(pokemon.PokemonOwners);

            var categories = _context.PokemonCategories
                .Where(pc => pc.PokemonSpeciesId == pokemon.PokemonSpeciesId)
                .ToList();
            if (categories.Any())
                _context.PokemonCategories.RemoveRange(categories);

            _context.Pokemons.Remove(pokemon);
            return Save();
        }
    }
}
