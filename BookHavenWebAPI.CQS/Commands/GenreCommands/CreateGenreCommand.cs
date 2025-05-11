using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.GenreCommands
{
    public class CreateGenreCommand : IRequest<int>
    {
        public GenreDTO GenreDTO { get; set; }
    }
}
