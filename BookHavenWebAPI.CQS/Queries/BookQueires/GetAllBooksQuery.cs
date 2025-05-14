using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.BookQueires
{
    public class GetAllBooksQuery : IRequest<List<BookDTO>>
    { 
    }
}
