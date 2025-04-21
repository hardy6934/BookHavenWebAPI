using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.AccountQueries
{
    public class GetAccountByEmailQuery: IRequest<AccountDTO>
    {
        public string Email { get; set; }
    }
}
