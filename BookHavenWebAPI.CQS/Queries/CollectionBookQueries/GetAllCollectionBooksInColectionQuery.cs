using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionBookQueries
{
    public class GetAllCollectionBooksInColectionQuery: IRequest<List<CollectionBookDTO>>
    {
        public int AccountId { get; set; }
        public int CollectionId { get; set; }
    }
}
