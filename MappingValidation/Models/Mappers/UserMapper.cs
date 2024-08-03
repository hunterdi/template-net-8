using AutoMapper;
using Domain.Behaviors;
using Domain.Entities;
using Domain.Extensions;
using MappingValidation.Models.Commands;
using MappingValidation.Models.Queries;

namespace Mapping.Models.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //CreateMap<User, UserCreateCommand>()
            //    .ForMember(dest => dest.Role, opt => opt.Ignore())
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName))
            //    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
            //    .ReverseMap();

            CreateMap<UserCreateCommand, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password.ApplyHash()));

            CreateMap<PagedResponse<User>, PageQuery<UserQuery, long>>();
        }
    }
}
