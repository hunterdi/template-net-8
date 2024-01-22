namespace Domain.Common
{
    public interface IBaseEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset UpdatedAt { get; set; }
        bool IsDeleted { get; set; }
        DateTimeOffset? DeletedAt { get; set; }
        bool IsVisible { get; set; }
        bool IsActive { get; set; }

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
