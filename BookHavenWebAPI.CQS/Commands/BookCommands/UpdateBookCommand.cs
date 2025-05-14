using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.BookCommands
{
    public class UpdateBookCommand : IRequest<int>
    {
        public BookDTO dto { get; set; }
    }
}
