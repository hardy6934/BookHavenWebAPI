using AutoMapper;
using BookHavenWebAPI.CQS.Commands.BookCommands;
using BookHavenWebAPI.CQS.Commands.GenreCommands;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Database;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.BookCommandHandlers
{
    public class CreateBookCommandHandler: IRequestHandler<CreateBookCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public CreateBookCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var entEntry = await context.Books.AddAsync(mapper.Map<Book>(request.dto), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entEntry.Entity.Id;
        }
    }
}
