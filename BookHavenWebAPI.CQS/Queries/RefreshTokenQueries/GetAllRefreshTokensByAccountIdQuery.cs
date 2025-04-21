
using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.RefreshTokenQueries
{
    public class GetAllRefreshTokensByAccountIdQuery : IRequest<List<RefreshTokenDTO>>
    {
        public int AccountId { get; set; }
    }
}
