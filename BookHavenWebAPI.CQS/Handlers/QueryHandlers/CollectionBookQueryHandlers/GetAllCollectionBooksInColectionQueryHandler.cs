using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.CollectionBookQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.CollectionBookQueryHandlers
{
    public class GetAllCollectionBooksInColectionQueryHandler: IRequestHandler<GetAllCollectionBooksInColectionQuery, List<CollectionBookDTO>>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAllCollectionBooksInColectionQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CollectionBookDTO>> Handle(GetAllCollectionBooksInColectionQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.CollectionBooks.AsNoTracking()
                .Where(x => x.CollectionId.Equals(request.CollectionId) 
                && x.Collection.AccountId.Equals(request.AccountId))
                .Include(x=>x.Book).ToListAsync();
            return ent.Select(mapper.Map<CollectionBookDTO>).ToList();
        }
    }
}
