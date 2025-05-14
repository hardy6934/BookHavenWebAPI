

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionQueires
{
    public class GetAllCollectionsForAccountQuery : IRequest<List<CollectionDTO>>
    {
        public int AccountId { get; set; }
    }
}
