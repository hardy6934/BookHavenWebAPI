

using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.CollectionBookQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.CollectionBookQueryHandlers
{
    public class GetAllCollectionBooksInColectionForSearchQueryHandler : IRequestHandler<GetAllCollectionBooksInColectionForSearchQuery, List<CollectionBookDTO>>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAllCollectionBooksInColectionForSearchQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CollectionBookDTO>> Handle(GetAllCollectionBooksInColectionForSearchQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.CollectionBooks.AsNoTracking()
                .Where(x => x.CollectionId.Equals(request.CollectionId)
                && x.Collection.AccountId.Equals(request.AccountId)
                && x.Book.Name.Contains(request.Name))
                .Include(x=>x.Book).ToListAsync();
            return ent.Select(mapper.Map<CollectionBookDTO>).ToList();
        }
    }
}
