using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.CollectionQueires;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.CollectionQueryHandlers
{
    public class GetCollectionByNameForAccountForSearchQueryHandler : IRequestHandler<GetCollectionByNameForAccountQuery, CollectionDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetCollectionByNameForAccountForSearchQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CollectionDTO> Handle(GetCollectionByNameForAccountQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Collections.AsNoTracking()
                .FirstOrDefaultAsync(x => x.AccountId.Equals(request.AccountId) && x.Name.Equals(request.Name));
            return mapper.Map<CollectionDTO>(ent);
        }
    }
}
