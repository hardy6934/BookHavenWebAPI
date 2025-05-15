

using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.CollectionBookQueries;
using BookHavenWebAPI.CQS.Queries.CollectionQueires;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.CollectionBookQueryHandlers
{
    public class IsCollectionBookExistQueryHandler: IRequestHandler<IsCollectionBookExistQuery, bool>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public IsCollectionBookExistQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(IsCollectionBookExistQuery request, CancellationToken cancellationToken)
        {
            return await context.CollectionBooks
                .AnyAsync(x=>x.BookId.Equals(request.BookId) && x.CollectionId.Equals(request.CollectionId));
        }
    }
}
