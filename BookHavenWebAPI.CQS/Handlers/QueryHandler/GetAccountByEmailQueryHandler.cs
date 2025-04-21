using AutoMapper;
using BookHaven.Core.DataTransferObjects;
using BookHaven.CQS.Queries;
using BookHaven.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHaven.CQS.Handlers.QueryHandler
{
    public class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, AccountDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAccountByEmailQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AccountDTO> Handle(GetAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(request.Email), cancellationToken);
            return mapper.Map<AccountDTO>(ent);
        }
    }
}
