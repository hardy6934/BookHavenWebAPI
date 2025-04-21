

using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.RefreshTokenQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.RefreshTokenQueryHandlers
{
    public class GetAllRefreshTokensByAccountIdQueryHandler : IRequestHandler<GetAllRefreshTokensByAccountIdQuery, List<RefreshTokenDTO>>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAllRefreshTokensByAccountIdQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<RefreshTokenDTO>> Handle(GetAllRefreshTokensByAccountIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await context.RefreshTokens.Where(x => x.AccountId.Equals(request.AccountId)).ToListAsync(cancellationToken);
            return entities.Select(mapper.Map<RefreshTokenDTO>).ToList();
        }
    }
}
