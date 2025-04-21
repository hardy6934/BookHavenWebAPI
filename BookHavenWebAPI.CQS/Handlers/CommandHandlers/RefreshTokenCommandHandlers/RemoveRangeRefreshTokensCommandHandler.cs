using AutoMapper;
using BookHavenWebAPI.CQS.Commands.RefreshTokenCommands;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.Database.Entities;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.RefreshTokenCommandHandlers
{
    public class RemoveRangeRefreshTokensCommandHandler : IRequestHandler<RemoveRangeRefreshTokensCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public RemoveRangeRefreshTokensCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveRangeRefreshTokensCommand request, CancellationToken cancellationToken)
        {
            context.RefreshTokens.RemoveRange(request.refreshTokenDTOs.Select(mapper.Map<RefreshToken>));

            return await context.SaveChangesAsync(cancellationToken);  
        }
    }
    {
    }
}
