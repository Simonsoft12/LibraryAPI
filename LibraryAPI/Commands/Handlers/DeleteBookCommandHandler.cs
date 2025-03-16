using LibraryAPI.Repositories.Book;
using MediatR;

namespace LibraryAPI.Commands.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteAsync(request.Id);
        }
    }
}