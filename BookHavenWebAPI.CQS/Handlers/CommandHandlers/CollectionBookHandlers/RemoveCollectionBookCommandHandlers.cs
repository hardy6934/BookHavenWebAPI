using AutoMapper;
using BookHavenWebAPI.CQS.Commands.CollectionBookCommands;
using BookHavenWebAPI.DataBase.Entities;
using BookHavenWebAPI.Database;
using MediatR; 

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.CollectionBookHandlers
{
    public class RemoveCollectionBookCommandHandlers : IRequestHandler<RemoveCollectionBookCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public RemoveCollectionBookCommandHandlers(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveCollectionBookCommand request, CancellationToken cancellationToken)
        {
            context.CollectionBooks.Remove(mapper.Map<CollectionBook>(request.CollectionBookDTO));
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
