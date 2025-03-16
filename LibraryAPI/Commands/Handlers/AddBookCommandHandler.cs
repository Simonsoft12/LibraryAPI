using LibraryAPI.Entities;
using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Repositories.Book;
using MediatR;

namespace LibraryAPI.Commands.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDTO>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDTO> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Dto.Title,
                Author = request.Dto.Author,
                ISBN = request.Dto.ISBN,
                StatusId = request.Dto.StatuId
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
    }
}