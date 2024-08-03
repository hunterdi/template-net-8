using MediatR;

namespace Domain.Behaviors
{
    public abstract record CreateCommand<TCommand> : IRequest<TCommand>
    {
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    };
}
