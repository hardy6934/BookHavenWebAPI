using AutoMapper;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.DataBase.Entities;
using MediatR; 

namespace BookHavenWebAPI.CQS.Commands.CollectionCommands
{
    public class RemoveCollectionCommandHandler : IRequestHandler<RemoveCollectionCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public RemoveCollectionCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveCollectionCommand request, CancellationToken cancellationToken)
        {
            context.Collections.Remove(mapper.Map<Collection>(request.CollectionDTO));
            return await context.SaveChangesAsync(cancellationToken); 
        }
    }
}
