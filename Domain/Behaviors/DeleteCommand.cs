using MediatR;

namespace Domain.Behaviors
{
    public abstract record DeleteCommand<TKey> : IRequest where TKey : IComparable
    {
        public required IReadOnlyList<TKey> Ids { get; set; }
    }
}
