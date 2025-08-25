namespace PokemonReviewApps.Request
{
    public class PokemonCreatedRequest
    {
        public string Nickname { get; set; }
        public DateTime BirthDate { get; set; }
        public int PokemonSpeciesId { get; set; }
        public List<int>? OwnerIds { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}
