using AutoMapper;
using Infrastructure.Behaviors.Extensions;
using Infrastructure.Behaviors.Providers;
using Infrastructure.Behaviors.Repositories;
using Infrastructure.Behaviors.Services;
using MappingValidation.Models.Queries;
using Microsoft.Extensions.Logging;

namespace Business.Services
{
    public class FileService : BaseService<Domain.Entities.File, long>, IFileService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly LocalStorageService _localStorageService;
        
        public FileService(IBaseRepository<Domain.Entities.File, long> repository, IMapper mapper, IBlobStorageService blobStorageService, LocalStorageService localStorageService, ILogger<FileService> logger) : base(repository, mapper, logger)
        {
            _blobStorageService = blobStorageService;
            _localStorageService = localStorageService;
        }

        public override async Task<TQuery> CreateAsync<TQuery, TCreateCommand>(TCreateCommand command, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Domain.Entities.File>(command);

            var createCommand = command as MappingValidation.Models.Commands.FileCreateCommand;

            if (createCommand?.File == null) throw new FileNotFoundException();

            var persistedName = createCommand.File.GeneratePersistedFileName();
            var path = await _localStorageService.UploadAsync(persistedName, createCommand.File, cancellationToken);

            entity.Extension = createCommand.File.GetExtension();
            entity.PersistedName = persistedName;
            entity.RealName = createCommand.File.FileName;
            entity.Path = path;

            var resultRepository = await _repository.AddAsync(entity, cancellationToken);

            await _repository.SaveChangeAsync(cancellationToken);

            var result = _mapper.Map<TQuery>(resultRepository);

            return result;
        }

        public async Task<FileQuery> DownloadAsync(long id)
        {
            var fileEntity = await _repository.GetByIdAsync(id);

            if (fileEntity == null) throw new FileNotFoundException(id.ToString());

            await _localStorageService.DownloadAsync(fileEntity);

            var result = _mapper.Map<FileQuery>(fileEntity);

            return result;
        }
    }
}
