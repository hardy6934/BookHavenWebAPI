using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.AccountQueries
{
    public class GetAccountByIdQuery: IRequest<AccountDTO>
    {
        public int Id { get; set; }
    }
}
