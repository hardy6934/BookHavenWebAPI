
using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.CollectionBookCommands
{
    public class UpdateCollectionBookCommand : IRequest<int>
    {
        public CollectionBookDTO CollectionBookDTO { get; set; }
    }
}
