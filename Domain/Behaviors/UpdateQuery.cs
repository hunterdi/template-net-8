namespace Domain.Behaviors
{
    public abstract record UpdateQuery<TKey> where TKey : IComparable
    {
        public required TKey Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    }
}