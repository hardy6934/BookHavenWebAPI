using AutoMapper;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Database;
using MediatR;
using BookHavenWebAPI.CQS.Commands.RefreshTokenCommands;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.RefreshTokenCommandHandlers
{
    class AddRefreshTokenCommandHandler : IRequestHandler<AddRefreshTokenCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public AddRefreshTokenCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
         
        public async Task<int> Handle(AddRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var entEntry = await context.RefreshTokens.AddAsync(mapper.Map<RefreshToken>(request.refreshTokenDTO), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entEntry.Entity.Id;
        }
    }
}
