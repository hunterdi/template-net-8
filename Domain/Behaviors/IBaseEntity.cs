namespace Domain.Behaviors
{
    public interface IBaseEntity
    {
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset UpdatedOn { get; set; }
        bool IsDeleted { get; set; }
        DateTimeOffset? DeletedOn { get; set; }
        bool IsVisible { get; set; }
        bool IsActive { get; set; }
        Guid Version { get; set; }

        void Created();
        void UndoDelete();
        void Deleted();
        void Modified();
    }

    public interface IBaseEntity<TKey> : IBaseEntity where TKey : IComparable
    {
        TKey Id { get; set; }
    }
}
