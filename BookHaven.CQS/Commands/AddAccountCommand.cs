using BookHaven.Core.DataTransferObjects;
using MediatR;

namespace BookHaven.CQS.Commands
{
    public class AddAccountCommand: IRequest<int>
    {
        public AccountDTO accountDTO;
    }
}
