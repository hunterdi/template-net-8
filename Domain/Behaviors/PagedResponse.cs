namespace Domain.Behaviors
{
    public sealed class PagedResponse<TEntity> where TEntity : class
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => TotalPages > CurrentPage;
        public IReadOnlyList<TEntity>? Result { get; set; }

        public PagedResponse(IReadOnlyList<TEntity>? result, int totalRecords, int pageNumber, int pageSize)
        {
            TotalRecords = totalRecords;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling((double)totalRecords / PageSize);
            Result = result;
        }
    }
}
