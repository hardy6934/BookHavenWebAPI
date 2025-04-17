

using AutoMapper;
using BookHaven.Core.DataTransferObjects;
using BookHaven.CQS.Queries;
using BookHaven.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.CQS.Handlers.QueryHandler
{
    class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAccountByIdQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AccountDTO> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Accounts.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
            return mapper.Map<AccountDTO>(ent);
        }
    }
}
