using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.CollectionBookQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.CollectionBookQueryHandlers
{
    public class GetCollectionBookByIdQueryHandler: IRequestHandler<GetCollectionBookByIdQuery, CollectionBookDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetCollectionBookByIdQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CollectionBookDTO> Handle(GetCollectionBookByIdQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.CollectionBooks.AsNoTracking()
                .Where(x => x.Id.Equals(request.Id) && x.Collection.AccountId.Equals(request.AccountId))
                .Include(x=>x.Collection)
                .Include(x=>x.Book)
                .FirstOrDefaultAsync();
            return mapper.Map<CollectionBookDTO>(ent);
        }
    }
}
