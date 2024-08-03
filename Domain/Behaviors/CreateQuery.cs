using MediatR;

namespace Domain.Behaviors
{
    public abstract record CreateQuery
    {
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    };
}
