using BookHaven.Core.DataTransferObjects;
using MediatR;

namespace BookHaven.CQS.Queries
{
    public class GetAccountByEmailQuery: IRequest<AccountDTO>
    {
        public string Email { get; set; }
    }
}
