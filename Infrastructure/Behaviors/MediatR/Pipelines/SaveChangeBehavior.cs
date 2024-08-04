using Infrastructure.Behaviors.Repositories;
using Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Behaviors.MediatR.Pipelines
{
    public sealed class SaveChangeBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly PostgresDBContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public SaveChangeBehavior(PostgresDBContext dbContext, IUnitOfWork unitOfWork, ILogger<SaveChangeBehavior<TRequest, TResponse>> logger)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (IsNotCommand()) return await next();

            var response = await _unitOfWork.TryExecuteAsync<TResponse>(next, cancellationToken);

            return response;
        }

        private static bool IsNotCommand()
        {
            return !typeof(TRequest).Name.EndsWith("Command");
        }
    }
}
