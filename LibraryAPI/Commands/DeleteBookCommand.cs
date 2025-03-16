using MediatR;

namespace LibraryAPI.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}