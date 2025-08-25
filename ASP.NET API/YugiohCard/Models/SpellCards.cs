using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YugiohCard.Models
{
    public class SpellCard : CardBase
    {
        [Required(ErrorMessage = "Spell card must have a type")]
        [JsonPropertyOrder(2)]
        public SpellType Type { get; set; }
    }
}
