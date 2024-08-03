namespace Domain.Behaviors
{
    public abstract record PageQuery<TQuery, TKey> where TQuery : BaseResultQuery<TKey> where TKey : IComparable
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public IReadOnlyList<TQuery>? Result { get; set; }
    }
}
