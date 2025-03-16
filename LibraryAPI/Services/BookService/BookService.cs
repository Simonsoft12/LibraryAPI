using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Enums;
using LibraryAPI.Models.Book;
using LibraryAPI.Repositories.Book;
using LibraryAPI.Validators;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync(BookSearchModel model)
        {
            try
            {
                return await _bookRepository.GetAllAsync(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllBooksAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Entities.Book> GetBookByIdAsync(int id)
        {
            try
            {
                return await _bookRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBookByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<BookDTO> AddBookAsync(CreateBookDTO dto)
        {
            try
            {
                var book = new Entities.Book
                {
                    Title = dto.Title,
                    Author = dto.Author,
                    ISBN = dto.ISBN,
                    StatusId = dto.StatuId
                };

                await _bookRepository.AddAsync(book);
                return new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    StatusId = book.StatusId
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddBookAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateBookAsync(int id, UpdateBookDTO dto)
        {
            try
            {
                var existingBook = await _bookRepository.GetByIdAsync(id);
                if (existingBook == null)
                {
                    throw new KeyNotFoundException("Book not found.");
                }

                if (!BookStatusValidator.IsStatusTransitionValid(existingBook.Status, (BookStatus)(dto.StatusId)))
                {
                    throw new InvalidOperationException("Invalid status transition.");
                }

                existingBook.Title = dto.Title;
                existingBook.Author = dto.Author;
                existingBook.ISBN = dto.ISBN;
                existingBook.StatusId = dto.StatusId;

                await _bookRepository.UpdateAsync(existingBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateBookAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            try
            {
                await _bookRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteBookAsync: {ex.Message}");
                throw;
            }
        }
    }
}