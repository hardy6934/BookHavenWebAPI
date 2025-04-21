 
using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.AccountQueries
{
    public class GetAccountByRefreshTokensTokenQuery : IRequest<AccountDTO>
    {
        public Guid Token { get; set; }
    }
}
