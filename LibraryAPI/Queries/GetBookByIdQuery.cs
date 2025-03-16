using MediatR;

namespace LibraryAPI.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Entities.Book>
    {
        public int Id { get; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}