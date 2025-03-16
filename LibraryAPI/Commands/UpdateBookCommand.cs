using LibraryAPI.Entities.DTOs.Book;
using MediatR;

namespace LibraryAPI.Commands
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; }
        public UpdateBookDTO Dto { get; }

        public UpdateBookCommand(int id, UpdateBookDTO dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}