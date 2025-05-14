

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionQueires
{ 
    public class GetCollectionByNameForAccountForSearchQuery : IRequest<List<CollectionDTO>>
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
    }
}
