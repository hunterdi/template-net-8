namespace Domain.Behaviors
{
    public abstract record BaseResultQuery<TKey> where TKey : IComparable
    {
        public required TKey Id { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
