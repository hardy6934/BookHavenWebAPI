using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.BookQueires;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.BookQueryHandlers
{
    public class GetBookByNameQueryHandler : IRequestHandler<GetBookByNameQuery, BookDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetBookByNameQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByNameQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Equals(request.Name)); 
            return mapper.Map<BookDTO>(ent);
        }
    }
}
