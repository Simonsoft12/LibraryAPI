namespace LibraryAPI.Models.Book
{
    public class BookSearchModel
    {
        public string? SortBy { get; set; }
        public int? Page { get; set; }
        public int? PageSize {  get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int? StatusId { get; set; }
    }
}