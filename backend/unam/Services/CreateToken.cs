
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace unam.Services
{
    public class CreateToken : IToken
    {
        private readonly IConfiguration _configuration;

        public CreateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public (string accessToken, string refreshToken) GenerateToken(string username)
        {
            var jwtSettings = _configuration.GetSection("jwt");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["key"]!));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["issuer"],
                audience: jwtSettings["audience"],
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: claims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            var access = new JwtSecurityTokenHandler().WriteToken(token);

            var refresh = Guid.NewGuid().ToString();

            return (access, refresh);
        }
    }
}
