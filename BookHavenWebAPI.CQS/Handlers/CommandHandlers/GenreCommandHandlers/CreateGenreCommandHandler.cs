using AutoMapper;
using BookHavenWebAPI.CQS.Commands.GenreCommands;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.Database.Entities;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.GenreCommandHandlers
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public CreateGenreCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var entEntry = await context.Genre.AddAsync(mapper.Map<Genre>(request.GenreDTO), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entEntry.Entity.Id;
        }
    }
}
