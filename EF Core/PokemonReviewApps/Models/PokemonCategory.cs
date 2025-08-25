namespace PokemonReviewApps.Models
{
    public class PokemonCategory : BaseEntity
    {
        public int PokemonSpeciesId { get; set; }
        public int CategoryId { get; set; }
        public PokemonSpecies PokemonSpecies { get; set; }
        public Category Category { get; set; }
    }
}
