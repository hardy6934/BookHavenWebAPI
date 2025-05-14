using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.BookQueires
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public int Id { get; set; }
    }
}
