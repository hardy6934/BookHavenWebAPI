

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.CollectionCommands
{
    public class RemoveCollectionCommand : IRequest<int>
    {
        public CollectionDTO CollectionDTO { get; set; }
    }
}
