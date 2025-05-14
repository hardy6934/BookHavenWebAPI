

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.CollectionCommands
{
    public class UpdateCollectionCommand : IRequest<int>
    {
        public CollectionDTO CollectionDTO { get; set; }
    }
}
