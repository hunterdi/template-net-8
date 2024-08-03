using AutoMapper;
using Domain.Behaviors;
using Infrastructure.Behaviors.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Behaviors.Services
{
    public abstract class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IComparable
    {
        protected readonly IBaseRepository<TEntity, TKey> _repository;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        public BaseService(IBaseRepository<TEntity, TKey> repository, IMapper mapper, ILogger<BaseService<TEntity, TKey>> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public virtual async Task<TResultQuery> CreateAsync<TResultQuery, TCreateCommand>(TCreateCommand command, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey> where TCreateCommand : IRequest<TResultQuery>
        {
            var entity = _mapper.Map<TEntity>(command);

            var resultRepository = await _repository.AddAsync(entity, cancellationToken);

            await _repository.SaveChangeAsync(cancellationToken);

            var result = _mapper.Map<TResultQuery>(resultRepository);
            _repository.Dispose();
            
            return result;
        }

        public virtual async Task<IReadOnlyCollection<TResultQuery>> CreateAsync<TResultQuery, TCreateCommand>(IEnumerable<TCreateCommand> commands, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey> where TCreateCommand : IRequest<TResultQuery>
        {
            var entities = _mapper.Map<TEntity[]>(commands);

            var resultRepository = await _repository.AddRangeAsync(entities, cancellationToken);

            await _repository.SaveChangeAsync(cancellationToken);

            var result = _mapper.Map<TResultQuery[]>(resultRepository);
            _repository.Dispose();
            
            return result;
        }

        public virtual async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) throw new Exception();

            await _repository.DeleteAsync(entity, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            _repository.Dispose();
        }

        public virtual async Task UpdateAsync<TUpdateCommand>(TKey id, TUpdateCommand command, CancellationToken cancellationToken = default) where TUpdateCommand : IRequest<TKey>
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) throw new Exception();

            var entityMapped = _mapper.Map(command, entity);

            await _repository.UpdateAsync(entityMapped, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            _repository.Dispose();
        }

        public virtual async Task UpdateAsync<TUpdateCommand>(IEnumerable<TUpdateCommand> commands, CancellationToken cancellationToken = default) where TUpdateCommand : IRequest<TKey>
        {
            var entityMapped = _mapper.Map<TEntity[]>(commands);

            if (entityMapped == null) throw new Exception();

            var tasks = entityMapped.Select(e =>
            {
                return _repository.UpdateAsync(e, cancellationToken);
            });

            await Task.WhenAll(tasks);
            await _repository.SaveChangeAsync(cancellationToken);
            _repository.Dispose();
        }

        public virtual async Task<PageQuery<TResultQuery, TKey>> GetPagedAsync<TResultQuery, TFilterQuery>(PageCommand<TFilterQuery> pageCommand, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey> where TFilterQuery : BaseFilterCommand
        {
            var modelMapped = _mapper.Map<PagingRequestModel<TEntity, TKey>>(pageCommand);

            var resultRepository = await _repository.GetPagedAsync(modelMapped, cancellationToken: cancellationToken);

            var resultMapped = _mapper.Map<PageQuery<TResultQuery, TKey>>(resultRepository);
            _repository.Dispose();

            return resultMapped;
        }

        public virtual async Task<TResultQuery> GetByIdAsync<TResultQuery>(TKey id, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey>
        {
            var resultRepository = await _repository.GetByIdAsync(id, cancellationToken);
            var resultMapped = _mapper.Map<TResultQuery>(resultRepository);
            _repository.Dispose();

            return resultMapped;
        }
    }
}
