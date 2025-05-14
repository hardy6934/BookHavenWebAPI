using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.BookCommands
{
    public class RemoveBookCommand : IRequest<int>
    {
        public BookDTO dto { get; set; }
    }
}
