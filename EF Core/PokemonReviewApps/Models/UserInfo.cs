using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApps.Models
{
    public class UserInfo : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefeshTokenExpiryTime { get; set; }
    }
}
