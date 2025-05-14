

using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.DataBase.Entities;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.CollectionCommands
{
    public class UpdateCollectionCommandHandler : IRequestHandler<UpdateCollectionCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public UpdateCollectionCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
        {
            context.Collections.Update(mapper.Map<Collection>(request.CollectionDTO));
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
