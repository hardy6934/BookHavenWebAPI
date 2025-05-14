using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.BookQueires
{
    public class GetBookByNameQuery: IRequest<BookDTO>
    {
        public string Name { get; set; }
    }
}
