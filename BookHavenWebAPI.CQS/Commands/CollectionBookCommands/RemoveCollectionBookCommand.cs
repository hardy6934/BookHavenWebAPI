using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.CollectionBookCommands
{
    public class RemoveCollectionBookCommand : IRequest<int>
    {
        public CollectionBookDTO CollectionBookDTO { get; set; }
    }
}
