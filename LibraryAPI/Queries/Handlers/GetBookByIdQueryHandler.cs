using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Repositories.Book;
using MediatR;

namespace LibraryAPI.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Entities.Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Entities.Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetByIdAsync(request.Id);
        }
    }
}