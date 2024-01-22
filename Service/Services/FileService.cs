using AutoMapper;
using Core.Common.Extensions;
using Core.Common.Providers;
using MappingValidation.Models.Commands;
using MappingValidation.Models.Queries;
using Repository.Common.Behaviors;
using Service.Common.Behaviors;

namespace Service.Services
{
    public class FileService : BaseService<Domain.Entities.File, Guid>, IFileService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly LocalStorageService _localStorageService;
        public FileService(IBaseRepository<Domain.Entities.File, Guid> repository, IMapper mapper, IBlobStorageService blobStorageService, LocalStorageService localStorageService) : base(repository, mapper)
        {
            this._blobStorageService = blobStorageService;
            this._localStorageService = localStorageService;
        }

        public override async Task<TQueryDTO> CreateAsync<TQueryDTO, TCreateCommandDTO>(TCreateCommandDTO dto, CancellationToken cancellationToken = default)
        {
            var entity = this._mapper.Map<Domain.Entities.File>(dto);

            var dtoCreateCommand = dto as FileCreateViewModel;

            if (dtoCreateCommand?.File == null) throw new FileNotFoundException();

            var persistedName = dtoCreateCommand.File.GeneratePersistedFileName();
            var path = await this._localStorageService.UploadAsync(persistedName, dtoCreateCommand.File, cancellationToken);

            entity.Extension = dtoCreateCommand.File.GetExtension();
            entity.PersistedName = persistedName;
            entity.RealName = dtoCreateCommand.File.FileName;
            entity.Path = path;

            var resultRepository = await this._repository.AddAsync(entity, cancellationToken);

            await this._repository.SaveChangeAsync(cancellationToken);

            var result = this._mapper.Map<TQueryDTO>(resultRepository);

            return result;
        }

        public async Task<FileViewModel> DownloadAsync(Guid id)
        {
            var fileEntity = await this._repository.GetByIdAsync(id);

            if (fileEntity == null) throw new FileNotFoundException(id.ToString());

            await this._localStorageService.DownloadAsync(fileEntity);

            var result = this._mapper.Map<FileViewModel>(fileEntity);

            return result;
        }
    }
}
