using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Queries.GenreQueries;
using BookHavenWebAPI.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHavenWebAPI.CQS.Handlers.QueryHandlers.GenreQueryHandlers
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDTO>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;

        public GetGenreByIdQueryHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GenreDTO> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Genre.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
            return mapper.Map<GenreDTO>(ent);
        }
    } 
}
