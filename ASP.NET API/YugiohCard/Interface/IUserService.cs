using YugiohCard.Models;

namespace YugiohCard.Interface
{
    public interface IUserService
    {
        UserInfo? Authenticate(string username, string password);
        UserInfo? Register(string username, string password, string email, string role = "User");
        bool UserExists(string username);
        string GenerateRefreshToken();
        void SaveRefreshToken(UserInfo user, string refreshToken);
        UserInfo? GetUserByRefreshToken(string refreshToken);
        UserInfo? GetUserByUserName(string username);
    }
}
