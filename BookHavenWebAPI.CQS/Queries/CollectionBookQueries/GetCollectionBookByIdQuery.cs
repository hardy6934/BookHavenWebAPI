
using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionBookQueries
{
    public class GetCollectionBookByIdQuery: IRequest<CollectionBookDTO>
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
    }
}
