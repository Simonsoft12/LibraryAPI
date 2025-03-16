using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Models.Book;
using MediatR;
using System.Collections.Generic;

namespace LibraryAPI.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDTO>>
    {
        public BookSearchModel SearchModel { get; }

        public GetBooksQuery(BookSearchModel searchModel)
        {
            SearchModel = searchModel;
        }
    }
}