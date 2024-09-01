using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Repository.Postgres;
using System.Security.Claims;

namespace Business.Services
{
    public class RoleService: IRoleService
    {
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly IRoleRepository _roleRepository;

        public RoleService(RoleManager<IdentityRole<long>> roleManager, IRoleRepository roleRepository)
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
        }

        public async Task<IReadOnlyList<RoleClaim>> GetClaimsAsync(IReadOnlyList<string> rolesName)
        {
            var roles = await _roleRepository.GetRoleByAsync(e => rolesName.Contains(e.Name));
            var roleIds = roles.Select(r => r.Id).ToList();

            var response = (await _roleRepository.GetClaimsByAsync(e => roleIds.Contains(e.RoleId))) ?? throw new Exception("");

            return response;
        }
    }
}
