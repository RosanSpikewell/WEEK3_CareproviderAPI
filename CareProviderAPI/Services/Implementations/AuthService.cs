using CareProviderAPI.Data.DTOs.UserDTO;
using CareProviderAPI.Data.Repositories.Implementations;
using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using CareProviderAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CareProviderAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public AuthService(IUserRepository userRepository,IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }
        public async Task<string> Register(RegisterDTO registerDTO)
        {
            var existingUser = await userRepository.GetUserByEmail(registerDTO.Email);
            if (existingUser != null)
                return "Email already exists.";

            var hashedPassword = HashPassword(registerDTO.Password);

            var user = new User
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                PasswordHash = hashedPassword
            };

            await userRepository.AddUser(user);
            return "User registered successfully!";
        }

        public async Task<LoginResponseModel> ValidateUser(LoginDTO loginDTO)
        {
            var user = await userRepository.GetUserByEmail(loginDTO.Email);
            if (user == null) return null;


            if (!VerifyPassword(loginDTO.Password, user.PasswordHash)) {
                return null;
            }
            var issuer = configuration["JwtConfig:Issuer"];
            var audience = configuration["JwtConfig:Audience"];
            var key = configuration["JwtConfig:Key"];
            var tokenValidityMins = configuration.GetValue<int>("JwtConfig:TokenValidityMins");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name,loginDTO.Email)
                }),
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = audience
            }; 

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return new LoginResponseModel
            {
                AccessToken = accessToken,
                Email = loginDTO.Email,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };

        }
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return HashPassword(enteredPassword) == storedHash;
        }
    }
}
