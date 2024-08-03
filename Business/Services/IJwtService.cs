using Domain.Entities;

namespace Business.Services
{
    public interface IJwtService
    {
        string GetJwtToken(User user, IReadOnlyList<RoleClaim> additionalClaims);
    }
}
