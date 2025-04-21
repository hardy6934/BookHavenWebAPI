

using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.AccountQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.AccountQueryHandlers
{
    class GetAccountByRefreshTokensTokenQueryHandler : IRequestHandler<GetAccountByRefreshTokensTokenQuery, AccountDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAccountByRefreshTokensTokenQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper; 
        }

        public async Task<AccountDTO> Handle(GetAccountByRefreshTokensTokenQuery request, CancellationToken cancellationToken)
        {
            var refreshToken = await context.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(x => x.Token.Equals(request.Token), cancellationToken);

            if (refreshToken is not null)
            {
                var account = await context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(refreshToken.Id), cancellationToken);
                return mapper.Map<AccountDTO>(account);
            }
            else return null;
        }
    }
}
