namespace Domain.Behaviors
{
    public sealed class PagingRequestModel<TEntity, TKey> where TEntity : IBaseEntity<TKey> where TKey : IComparable
    {
        const int MAX_PAGE_SIZE = 100;
        public required int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public required int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
            }
        }
        public required string OrderBy { get; set; }
        public required bool OrderByDescending { get; set; } = true;
        public required TEntity Filter { get; set; }
    }
}
