using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.GenreQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.GenreQueryHandlers
{
    public class GetGenreByNameQueryHandler : IRequestHandler<GetGenreByNameQuery, GenreDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetGenreByNameQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GenreDTO> Handle(GetGenreByNameQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Genre.AsNoTracking().FirstOrDefaultAsync(x=>x.Name.Equals(request.Name));
            return mapper.Map<GenreDTO>(ent);
        }
    }
}
