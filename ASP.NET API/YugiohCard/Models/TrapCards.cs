using System.ComponentModel.DataAnnotations;

namespace YugiohCard.Models
{
    public class TrapCard : CardBase
    {
        [Required(ErrorMessage = "Trap card must have a type")]
        public TrapType Type { get; set; }
    }
}
