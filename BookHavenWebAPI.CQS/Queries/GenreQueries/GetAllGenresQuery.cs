using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.GenreQueries
{
    public class GetAllGenresQuery: IRequest<List<GenreDTO>>
    {
    }
}
