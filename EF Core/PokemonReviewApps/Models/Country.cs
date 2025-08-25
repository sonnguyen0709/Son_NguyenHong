namespace PokemonReviewApps.Models
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
