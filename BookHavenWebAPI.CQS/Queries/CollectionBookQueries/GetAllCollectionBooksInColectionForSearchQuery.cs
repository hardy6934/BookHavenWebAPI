

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionBookQueries
{
    public class GetAllCollectionBooksInColectionForSearchQuery: IRequest<List<CollectionBookDTO>>
    {
        public string Name { get; set; }
        public int CollectionId { get; set; }
        public int AccountId { get; set; }
    }
}
