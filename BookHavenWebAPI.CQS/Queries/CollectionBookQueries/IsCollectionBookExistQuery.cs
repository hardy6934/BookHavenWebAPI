

using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionBookQueries
{
    public class IsCollectionBookExistQuery: IRequest<bool>
    {
        public int BookId { get; set; }
        public int CollectionId { get; set; }
    }
}
