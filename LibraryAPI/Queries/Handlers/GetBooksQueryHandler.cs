using AutoMapper;
using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Queries;
using LibraryAPI.Repositories.Book;
using MediatR;

namespace LibraryAPI.Handlers
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync(request.SearchModel);
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }
    }
}