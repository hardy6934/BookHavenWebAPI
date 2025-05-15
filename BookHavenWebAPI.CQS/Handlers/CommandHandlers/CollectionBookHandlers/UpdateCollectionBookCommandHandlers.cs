using AutoMapper;
using BookHavenWebAPI.CQS.Commands.BookCommands;
using BookHavenWebAPI.CQS.Commands.CollectionBookCommands;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Database;
using MediatR;
using BookHavenWebAPI.DataBase.Entities;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.CollectionBookHandlers
{
    public class UpdateCollectionBookCommandHandlers : IRequestHandler<UpdateCollectionBookCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public UpdateCollectionBookCommandHandlers(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateCollectionBookCommand request, CancellationToken cancellationToken)
        {
            context.CollectionBooks.Update(mapper.Map<CollectionBook>(request.CollectionBookDTO));
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
