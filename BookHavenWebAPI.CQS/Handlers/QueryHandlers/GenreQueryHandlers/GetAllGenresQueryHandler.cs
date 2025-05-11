using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.GenreQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.GenreQueryHandlers
{
    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, List<GenreDTO>>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetAllGenresQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GenreDTO>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Genre.AsNoTracking().ToListAsync();
            return ent.Select(mapper.Map<GenreDTO>).ToList();
        }
    }
}
