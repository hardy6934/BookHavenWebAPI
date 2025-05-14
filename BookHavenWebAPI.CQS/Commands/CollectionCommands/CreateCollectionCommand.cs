

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.CollectionCommands
{
    public class CreateCollectionCommand: IRequest<int>
    {
        public CollectionDTO CollectionDTO { get; set; }
    }
}
