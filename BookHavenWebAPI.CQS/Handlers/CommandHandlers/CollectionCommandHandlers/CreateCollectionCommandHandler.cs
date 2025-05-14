using AutoMapper; 
using BookHavenWebAPI.Database;
using MediatR;
using BookHavenWebAPI.DataBase.Entities;

namespace BookHavenWebAPI.CQS.Commands.CollectionCommands
{
    public class CreateCollectionCommandHandler: IRequestHandler<CreateCollectionCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public CreateCollectionCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
        {
            var entEntry = await context.Collections.AddAsync(mapper.Map<Collection>(request.CollectionDTO), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entEntry.Entity.Id;
        }
    }
}
