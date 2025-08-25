namespace PokemonReviewApps.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PokemonSpecies { get; set; }
        public List<OwnerDto>? Owners { get; set; }
        public List<CategoryDto>? Categories { get; set; }
    }
}
