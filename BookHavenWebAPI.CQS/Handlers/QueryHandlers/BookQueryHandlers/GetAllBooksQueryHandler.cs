using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.BookQueires;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.BookQueryHandlers
{
    public class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, List<BookDTO>>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAllBooksQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Books.AsNoTracking().ToListAsync();
            return ent.Select(mapper.Map<BookDTO>).ToList();
        }
    }
}
