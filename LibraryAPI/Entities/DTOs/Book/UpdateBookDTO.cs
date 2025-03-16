namespace LibraryAPI.Entities.DTOs.Book
{
    public class UpdateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int StatusId { get; set; }
    }
}
