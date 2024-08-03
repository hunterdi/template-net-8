using AutoMapper;
using Domain.Behaviors;
using MappingValidation.Models.Queries;
using Microsoft.AspNetCore.Identity;

namespace Mapping.Models.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<PagedResponse<IdentityRole<long>>, PageQuery<RoleQuery, long>>();
        }
    }
}
