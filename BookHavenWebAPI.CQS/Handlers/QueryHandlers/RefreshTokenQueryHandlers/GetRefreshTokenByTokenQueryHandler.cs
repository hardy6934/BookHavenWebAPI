using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.RefreshTokenQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.RefreshTokenQueryHandlers
{
    public class GetRefreshTokenByTokenQueryHandler : IRequestHandler<GetRefreshTokenByTokenQuery, RefreshTokenDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetRefreshTokenByTokenQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RefreshTokenDTO> Handle(GetRefreshTokenByTokenQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token.Equals(request.Token), cancellationToken);
            return mapper.Map<RefreshTokenDTO>(ent);
        }
    }
}
