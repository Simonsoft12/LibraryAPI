using LibraryAPI.Entities.DTOs.Book;
using MediatR;

namespace LibraryAPI.Commands
{
    public class AddBookCommand : IRequest<BookDTO>
    {
        public CreateBookDTO Dto { get; }

        public AddBookCommand(CreateBookDTO dto)
        {
            Dto = dto;
        }
    }
}