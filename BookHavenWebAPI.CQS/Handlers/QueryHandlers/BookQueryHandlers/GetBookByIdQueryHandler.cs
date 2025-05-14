using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.BookQueires;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.BookQueryHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetBookByIdQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
            return mapper.Map<BookDTO>(ent);
        }
    }
}
