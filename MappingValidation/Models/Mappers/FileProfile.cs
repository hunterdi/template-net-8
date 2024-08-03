
using AutoMapper;
using Domain.Behaviors;
using MappingValidation.Models.Commands;
using MappingValidation.Models.Queries;

namespace MappingValidation.Models.Mappers
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<Domain.Entities.File, FileQuery>();
            CreateMap<FileFilterCommand, Domain.Entities.File>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((FileFilterCommand src, Domain.Entities.File dest, object srcMember) => srcMember != null);
                });
            CreateMap<FileCreateCommand, Domain.Entities.File>();
            CreateMap<FileUpdateCommand, Domain.Entities.File>();
            CreateMap<PagedResponse<Domain.Entities.File>, PageQuery<FileQuery, long>>();
            CreateMap<PageCommand<FileFilterCommand>, PagingRequestModel<Domain.Entities.File, long>>()
                .ForMember<Domain.Entities.File>(dest => dest.Filter, opt =>
                {
                    opt.Condition(src => src.Filter != null);
                });
        }
    }
}
