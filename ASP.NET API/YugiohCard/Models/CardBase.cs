using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YugiohCard.Models
{
    public abstract class CardBase
    {
        [Required(ErrorMessage = "Card must have an id")]
        [JsonPropertyOrder(0)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Card's name cannot be blank")]
        [JsonPropertyOrder(1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Card must have description")]
        [JsonPropertyOrder(9)]
        public string Effect { get; set; }

        [JsonPropertyOrder(10)]
        public string ImageUrl { get; set; }

    }
}
