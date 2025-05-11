using AutoMapper;
using BookHavenWebAPI.CQS.Commands.GenreCommands;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.Database.Entities;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.GenreCommandHandlers
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public UpdateGenreCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var entEntry = context.Genre.Update(mapper.Map<Genre>(request.GenreDTO));
             
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
