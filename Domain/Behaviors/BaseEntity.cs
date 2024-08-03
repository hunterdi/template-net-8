namespace Domain.Behaviors
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey> where TKey : IComparable
    {
        public required TKey Id { get; set; }
        public required bool IsActive { get; set; }
        public required DateTimeOffset CreatedOn { get; set; }
        public required DateTimeOffset UpdatedOn { get; set; }
        public required bool IsVisible { get; set; }
        public required bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        public void Created()
        {
            CreatedOn = DateTimeOffset.UtcNow;
            Modified();
            IsActive = true;
            IsVisible = true;
            UndoDelete();
        }

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedOn = null;
        }

        public void Deleted()
        {
            Modified();
            IsDeleted = true;
            DeletedOn = DateTimeOffset.UtcNow;
        }

        public void Modified()
        {
            UpdatedOn = DateTimeOffset.UtcNow;
        }

    }
}
