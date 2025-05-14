

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionQueires
{
    public class GetCollectionByIdForAccountQuery : IRequest<CollectionDTO>
    {
        public int AccountId { get; set; }
        public int Id { get; set; }
    }
}
