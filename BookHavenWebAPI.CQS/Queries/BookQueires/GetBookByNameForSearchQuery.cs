using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR; 

namespace BookHavenWebAPI.CQS.Queries.BookQueires
{
    public class GetBookByNameForSearchQuery : IRequest<List<BookDTO>>
    {
        public string Name { get; set; }
    }
}
