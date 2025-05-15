using AutoMapper;
using BookHavenWebAPI.CQS.Commands.BookCommands;
using BookHavenWebAPI.CQS.Commands.CollectionBookCommands;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Database;
using MediatR;
using BookHavenWebAPI.DataBase.Entities;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.CollectionBookHandlers
{
    public class CreateCollectionBookCommandHandlers : IRequestHandler<CreateCollectionBookCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public CreateCollectionBookCommandHandlers(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateCollectionBookCommand request, CancellationToken cancellationToken)
        {
            var entEntry = await context.CollectionBooks
                .AddAsync(mapper.Map<CollectionBook>(request.CollectionBookDTO), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entEntry.Entity.Id;
        }
    }
}
