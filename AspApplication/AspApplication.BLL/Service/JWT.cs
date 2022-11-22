using AspApplication.BLL.Interfaces;
using AspApplication.Domain;
using AspApplication.Domain.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspApplication.BLL.Service
{
    public class JWT : IJWT
    {
        private readonly JWTSettings _options;

        public JWT(IOptions<JWTSettings> options)
        {
            _options = options.Value;
        }

        public string GetToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("id", $"{user.Id}")
            };
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha512Signature));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string Validate(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_options.Key);
            handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out var joken);
            var id = (joken as JwtSecurityToken).Claims.FirstOrDefault(x => x.Type == "id").Value;
            return id;
        }
    }
}
