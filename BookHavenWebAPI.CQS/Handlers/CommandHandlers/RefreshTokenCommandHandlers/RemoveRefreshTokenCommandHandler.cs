using AutoMapper;
using BookHavenWebAPI.CQS.Commands.RefreshTokenCommands;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.Database.Entities;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.RefreshTokenCommandHandlers
{
    public class RemoveRefreshTokenCommandHandler : IRequestHandler<RemoveRefreshTokenCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public RemoveRefreshTokenCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            context.RefreshTokens.Remove(mapper.Map<RefreshToken>(request.refreshTokenDTO)); 

            return await context.SaveChangesAsync(cancellationToken); 
        }
    }
}
