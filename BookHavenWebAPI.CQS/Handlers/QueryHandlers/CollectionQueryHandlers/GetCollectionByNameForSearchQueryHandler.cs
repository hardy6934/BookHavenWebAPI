using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.CollectionQueires;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.CollectionQueryHandlers
{
    public class GetCollectionByNameForSearchQueryHandler : IRequestHandler<GetCollectionByNameForAccountForSearchQuery, List<CollectionDTO>>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetCollectionByNameForSearchQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CollectionDTO>> Handle(GetCollectionByNameForAccountForSearchQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Collections.AsNoTracking()
                .Where(x => x.AccountId.Equals(request.AccountId) && x.Name.Contains(request.Name)).ToListAsync();
            return ent.Select(mapper.Map<CollectionDTO>).ToList();
        }
    }
}
