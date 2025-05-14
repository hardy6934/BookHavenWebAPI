

using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.CollectionQueires;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.CollectionQueryHandlers
{
    public class GetAllCollectionsForAccountQueryHandler : IRequestHandler<GetAllCollectionsForAccountQuery, List<CollectionDTO>>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAllCollectionsForAccountQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CollectionDTO>> Handle(GetAllCollectionsForAccountQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Collections.AsNoTracking().Where(x=>x.AccountId.Equals(request.AccountId)).ToListAsync();
            return ent.Select(mapper.Map<CollectionDTO>).ToList();
        }
    }
}
