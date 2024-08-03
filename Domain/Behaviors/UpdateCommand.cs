using MediatR;

namespace Domain.Behaviors
{
    public abstract record UpdateCommand<TKey> : IRequest where TKey : IComparable
    {
        public required TKey Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    }
}
