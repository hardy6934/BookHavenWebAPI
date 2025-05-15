using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.CollectionBookCommands
{
    public class CreateCollectionBookCommand: IRequest<int>
    {
        public CollectionBookDTO CollectionBookDTO { get; set; }
    }
}
