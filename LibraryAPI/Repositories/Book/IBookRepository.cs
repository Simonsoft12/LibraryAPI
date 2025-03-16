using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Models.Book;

namespace LibraryAPI.Repositories.Book
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDTO>> GetAllAsync(BookSearchModel model);

        Task<Entities.Book> GetByIdAsync(int id);

        Task AddAsync(Entities.Book book);

        Task UpdateAsync(Entities.Book book);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
