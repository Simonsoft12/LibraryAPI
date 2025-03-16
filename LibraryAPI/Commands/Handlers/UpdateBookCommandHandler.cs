using LibraryAPI.Enums;
using LibraryAPI.Repositories.Book;
using LibraryAPI.Validators;
using MediatR;

namespace LibraryAPI.Commands.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _bookRepository.GetByIdAsync(request.Id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            if (!BookStatusValidator.IsStatusTransitionValid((BookStatus)existingBook.StatusId, (BookStatus)request.Dto.StatusId))
            {
                throw new InvalidOperationException("Invalid status transition.");
            }

            existingBook.Title = request.Dto.Title;
            existingBook.Author = request.Dto.Author;
            existingBook.ISBN = request.Dto.ISBN;
            existingBook.StatusId = request.Dto.StatusId;

            await _bookRepository.UpdateAsync(existingBook);
        }
    }
}