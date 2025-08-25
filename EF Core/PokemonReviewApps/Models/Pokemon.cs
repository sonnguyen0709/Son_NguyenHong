using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApps.Models
{
    public class Pokemon : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public int PokemonSpeciesId { get; set; }
        public string Nickname { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
    }
}
