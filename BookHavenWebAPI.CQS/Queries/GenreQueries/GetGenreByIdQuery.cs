using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.GenreQueries
{
    public class GetGenreByIdQuery: IRequest<GenreDTO>
    {
        public int Id { get; set; }
    }
}
