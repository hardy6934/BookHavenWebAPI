

using AutoMapper;
using BookHavenWebAPI.CQS.Commands.GenreCommands;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.Database.Entities;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.GenreCommandHandlers
{
    public class RemoveGenreCommandHandler : IRequestHandler<RemoveGenreCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public RemoveGenreCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
        {
            var entEntry = context.Genre.Remove(mapper.Map<Genre>(request.GenreDTO));

            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
