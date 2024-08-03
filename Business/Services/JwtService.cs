using Domain.Behaviors;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services
{
    public class JwtService : IJwtService
    {
        private readonly AuthenticationSettings _authenticationSettings;
        
        public JwtService(IOptions<AuthenticationSettings> authenticationSettings)
        {
            _authenticationSettings = authenticationSettings.Value;
        }

        public string GetJwtToken(User user, IReadOnlyList<RoleClaim> additionalClaims)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, Guid.NewGuid().ToString()),
            };

            if (additionalClaims.Count > 0)
            {
                var claimList = new List<Claim>(claims);
                var claimsName = additionalClaims.Select(e =>
                {
                    return new Claim(ClaimTypes.AuthenticationMethod, e.ClaimValue ?? throw new Exception(""));
                }).ToArray();

                claimList.AddRange(claimsName);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.IssuerSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: _authenticationSettings.ValidIssuer,
                audience: _authenticationSettings.ValidAudience,
                expires: DateTime.UtcNow.AddDays(_authenticationSettings.BearerTokenExpiration),
                claims: claims,
                signingCredentials: creds,
                notBefore: DateTime.UtcNow
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
