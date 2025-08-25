using System;
using System.Data;
using System.Security.Cryptography;
using YugiohCard.Data;
using YugiohCard.Models;
using YugiohCard.Interface;
using System.Text;

namespace YugiohCard.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public UserService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public UserInfo? Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;
            return user;
        }

        public UserInfo? Register(string username, string password, string email, string role = "User")
        {
            if (UserExists(username)) return null;
            var user = new UserInfo
            {
                UserName = username,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }
        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
        private string HashRefreshToken(string rawToken)
        {
            var secret = _config["TokenOptions:RefreshTokenKey"];
            var keyBytes = Encoding.UTF8.GetBytes(secret);
            var tokenBytes = Encoding.UTF8.GetBytes(rawToken);

            using var hmac = new HMACSHA256(keyBytes);
            var hashBytes = hmac.ComputeHash(tokenBytes);
            return Convert.ToBase64String(hashBytes);
        }
        public void SaveRefreshToken(UserInfo user, string rawToken)
        {
            var hashToken = HashRefreshToken(rawToken);
            user.RefreshToken = hashToken;
            user.RefeshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public UserInfo? GetUserByRefreshToken(string rawToken)
        {
            var hashToken = HashRefreshToken(rawToken);
            return _context.Users.FirstOrDefault(u =>
            u.RefreshToken == rawToken &&
            u.RefeshTokenExpiryTime > DateTime.UtcNow);
        }
        public UserInfo? GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }
    }

}
