namespace PokemonReviewApps.Models
{
    public class PokemonSpecies : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
