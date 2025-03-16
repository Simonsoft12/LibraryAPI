using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Models.Book;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync(BookSearchModel model);
        Task<Entities.Book> GetBookByIdAsync(int id);
        Task<BookDTO> AddBookAsync(CreateBookDTO dto);
        Task UpdateBookAsync(int id, UpdateBookDTO dto);
        Task DeleteBookAsync(int id);
    }
}