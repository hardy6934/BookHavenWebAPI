using BookHavenWebAPI.Core.DataTransferObjects; 
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.CollectionQueires
{
    public class GetCollectionByNameForAccountQuery: IRequest<CollectionDTO>
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
    }
}
