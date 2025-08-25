using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PokemonReviewApps.Interface;
using PokemonReviewApps.Models;
using PokemonReviewApps.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokemonReviewApps.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Get configuration from appsetting.json (JWT Key)
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (_userService.UserExists(request.UserName))
                return BadRequest("Username already taken");

            var user = _userService.Register(request.UserName, request.Password, request.Email, request.Role);
            return Ok(new { message = "Registration successful", user.UserId });
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _userService.Authenticate(request.UserName, request.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var rawRefreshToken = _userService.GenerateRefreshToken();
            var token = GenerateJwtToken(user);
            _userService.SaveRefreshToken(user, rawRefreshToken);

            return Ok(new
            {
                token,
                rawRefreshToken,
                role = user.Role
            });
        }

        [HttpPost("RefreshToken")]
        public IActionResult Refresh(RefreshRequest request)
        {
            var user = _userService.GetUserByRefreshToken(request.RefreshToken);
            if (user == null) return Unauthorized("Invalid refresh token");

            if (user.RefeshTokenExpiryTime == null || user.RefeshTokenExpiryTime <= DateTime.UtcNow)
            {
                return Unauthorized("Refresh token expired, please login again.");
            }

            var newJwtToken = GenerateJwtToken(user);
            return Ok(new
            {
                token = newJwtToken
            });
        }

        private string GenerateJwtToken(UserInfo user)
        {
            // The claims that store user information will be in the JWT.
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

            // SigningCredentials is the information used to sign JWT
            // Use a "key" and an Algorithmsto create a digital signature in the token
            // Key usually put in appdetting.json
            // HmasSha256 ensures that any change in the token will make the signature invalid
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create a token object containing user information (Claims)
            var token = new JwtSecurityToken(
                // Issuer: is an identifier string (usually a domain name or system name), 
                // You usually define it in appsettings.json
                issuer: _config["Jwt:Issuer"],
                // Audience (token recipient): determines who this token is for (which API, which application).
                audience: _config["Jwt:Audience"],
                // Claims is a list of information attached to the token
                claims: claims,
                // Token expiration time
                expires: DateTime.Now.AddHours(1),
                // Token signing information
                signingCredentials: creds);

            // Convert token into real JWT string (Header.Payload.Signature)
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
