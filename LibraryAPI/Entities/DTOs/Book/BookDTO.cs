
namespace LibraryAPI.Entities.DTOs.Book
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int StatusId { get; set; }
    }

}
