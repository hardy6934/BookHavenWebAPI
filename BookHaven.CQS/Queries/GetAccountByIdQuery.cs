

using BookHaven.Core.DataTransferObjects;
using MediatR;

namespace BookHaven.CQS.Queries
{
    public class GetAccountByIdQuery: IRequest<AccountDTO>
    {
        public int Id { get; set; }
    }
}
