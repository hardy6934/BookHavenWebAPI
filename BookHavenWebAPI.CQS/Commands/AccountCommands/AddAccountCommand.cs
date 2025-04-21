using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.AccountCommands
{
    public class AddAccountCommand: IRequest<int>
    {
        public AccountDTO accountDTO;
    }
}
