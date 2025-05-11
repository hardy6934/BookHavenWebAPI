using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.GenreQueries
{
    public class GetGenreByNameForSearchQuery: IRequest<List<GenreDTO>>
    {
        public string Name { get; set; } 
    }
}
