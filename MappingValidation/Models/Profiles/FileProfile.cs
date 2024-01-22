
using AutoMapper;
using Domain.Common;
using MappingValidation.Models.Commands;
using MappingValidation.Models.Common.Behaviors;
using MappingValidation.Models.Queries;

// https://code-maze.com/automapper-how-to-ignore-null-values/

namespace MappingValidation.Models.Profiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<Domain.Entities.File, FileViewModel>();
            CreateMap<FileFilterViewModel, Domain.Entities.File>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            CreateMap<FileCreateViewModel, Domain.Entities.File>();
            CreateMap<FileUpdateViewModel, Domain.Entities.File>();
            CreateMap<PagedResponse<Domain.Entities.File, Guid>, PagedResponseViewModel<FileViewModel, Guid>>();
            CreateMap<PagingRequestModelViewModel<FileFilterViewModel>, PagingRequestModel<Domain.Entities.File, Guid>>()
                .ForMember(dest => dest.Filter, opt =>
                {
                    opt.Condition(src => src.Filter != null);
                });
        }
    }
}
