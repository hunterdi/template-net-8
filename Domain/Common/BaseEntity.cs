namespace Domain.Common
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey> where TKey : IComparable
    {
        public required TKey Id { get; set; }
        public required bool IsActive { get; set; }
        public required DateTimeOffset CreatedAt { get; set; }
        public required DateTimeOffset UpdatedAt { get; set; }
        public required bool IsVisible { get; set; }
        public required bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public void Created()
        {
            CreatedAt = DateTimeOffset.UtcNow;
            Modified();
            IsActive = true;
            IsVisible = true;
            UndoDelete();
        }

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }

        public void Deleted()
        {
            Modified();
            IsDeleted = true;
            DeletedAt = DateTimeOffset.UtcNow;
        }

        public void Modified()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }

    }
}
