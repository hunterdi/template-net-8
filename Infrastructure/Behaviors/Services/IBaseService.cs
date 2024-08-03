using Domain.Behaviors;
using MediatR;

namespace Infrastructure.Behaviors.Services
{
    public interface IBaseService<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IComparable
    {
        Task<TResultQuery> CreateAsync<TResultQuery, TCreateCommand>(TCreateCommand command, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey> where TCreateCommand : IRequest<TResultQuery>;
        Task<IReadOnlyCollection<TResultQuery>> CreateAsync<TResultQuery, TCreateCommand>(IEnumerable<TCreateCommand> commands, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey> where TCreateCommand : IRequest<TResultQuery>;
        Task RemoveAsync(TKey id, CancellationToken cancellationToken = default);
        Task UpdateAsync<TUpdateCommand>(TKey id, TUpdateCommand command, CancellationToken cancellationToken = default) where TUpdateCommand : IRequest<TKey>;
        Task UpdateAsync<TUpdateCommand>(IEnumerable<TUpdateCommand> commands, CancellationToken cancellationToken = default) where TUpdateCommand : IRequest<TKey>;
        Task<PageQuery<TResultQuery, TKey>> GetPagedAsync<TResultQuery, TFilterCommand>(PageCommand<TFilterCommand> pageCommand, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey> where TFilterCommand : BaseFilterCommand;
        Task<TResultQuery> GetByIdAsync<TResultQuery>(TKey id, CancellationToken cancellationToken = default) where TResultQuery : BaseResultQuery<TKey>;
    }
}
