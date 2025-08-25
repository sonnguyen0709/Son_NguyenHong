using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YugiohCard.Models
{
    public class MonsterCard : CardBase, IValidatableObject
    {
        [Required(ErrorMessage = "Monter must have a race")]
        [JsonPropertyOrder(6)]
        public MonsterRace Race { get; set; }

        [Required(ErrorMessage = "Monster must have a type")]
        [JsonPropertyOrder(5)]
        public MonsterType Type { get; set; }

        [Range(1, 13, ErrorMessage = "Level of a monster must be between 1 and 13")]
        [JsonPropertyOrder(2)]
        public int? Level { get; set; }

        [Range(1, 13, ErrorMessage = "Rank of a XYZ monster must be between 1 and 13")]
        [JsonPropertyOrder(3)]
        public int? Rank { get; set; }

        [Range(1, 6, ErrorMessage = "Link of a Link monster must be between 1 and 6")]
        [JsonPropertyOrder(4)]
        public int? Link { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Atk must be positive")]
        [JsonPropertyOrder(7)]
        public int ATK { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "DEF must be positive")]
        [JsonPropertyOrder(8)]
        public int DEF { get; set; }

        // Custom method that checks for validity
        // Logical checking that the [Required], [Range] attributes cannot do
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Type == MonsterType.XYZ && (Rank == null || Rank < 1 || Rank > 13))
                yield return new ValidationResult("XYZ monsters must have a valid Rank between 1 and 13.", new[] { "Rank" });

            if (Type == MonsterType.Link && (Link == null || Link < 1 || Link > 6))
                yield return new ValidationResult("Link monsters must have a valid Link value between 1 and 6.", new[] { "Link" });

            if (Type != MonsterType.XYZ && Rank != null)
                yield return new ValidationResult("Only XYZ monsters can have a Rank.", new[] { "Rank" });

            if (Type != MonsterType.Link && Link != null)
                yield return new ValidationResult("Only Link monsters can have a Link value.", new[] { "Link" });

            if (Type != MonsterType.XYZ && Type != MonsterType.Link && (Level == null || Level < 1 || Level > 13))
                yield return new ValidationResult("Non-XYZ/Link monsters must have a valid Star between 1 and 13.", new[] { "Star" });
        }
    }

}
