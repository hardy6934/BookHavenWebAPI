using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.GenreQueries
{
    public class GetGenreByNameQuery: IRequest<GenreDTO>
    {
        public string Name { get; set; }
    }
}
