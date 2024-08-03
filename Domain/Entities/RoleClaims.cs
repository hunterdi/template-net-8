using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class RoleClaim: IdentityRoleClaim<long>
    {
        public bool IsEnable { get; set; } = true;
    }
}
