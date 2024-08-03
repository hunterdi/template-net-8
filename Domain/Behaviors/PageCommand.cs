using MediatR;

namespace Domain.Behaviors
{
    public abstract record PageCommand<TCommand> : IRequest where TCommand : BaseFilterCommand
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = "CreatedAt";
        public bool OrderByDescending { get; set; } = true;
        public required TCommand Filter { get; set; }
    }
}
