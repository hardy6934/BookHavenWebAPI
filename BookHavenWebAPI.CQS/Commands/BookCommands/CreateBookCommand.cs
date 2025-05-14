using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.BookCommands
{
    public class CreateBookCommand: IRequest<int>
    {
        public BookDTO dto { get; set; }
    }
}
