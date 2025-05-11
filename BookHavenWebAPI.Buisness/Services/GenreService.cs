using AutoMapper;
using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Commands.GenreCommands;
using BookHavenWebAPI.CQS.Queries.GenreQueries;
using MediatR;

namespace BookHavenWebAPI.Buisness.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;  
         
        public GenreService(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator; 
        }

        public async Task<int> CreateGenreAsync(GenreDTO dto)
        {
            var res  = await mediator.Send(new CreateGenreCommand()
            {
                GenreDTO = dto
            });
            return res;
        }

        public async Task<List<GenreDTO>> GetAllGenresAsnyc()
        {
            var res = await mediator.Send(new GetAllGenresQuery()
            { 
            });
            return res;
        }

        public async Task<List<GenreDTO>> GetAllGenresForSearchAsnyc(string name)
        {
            var res = await mediator.Send(new GetGenreByNameForSearchQuery()
            { 
                Name = name
            });
            return res;
        }

        public async Task<GenreDTO> GetGenreByIdAsnyc(int id)
        {
            var res = await mediator.Send(new GetGenreByIdQuery()
            {
                Id = id
            });
            return res;
        }

        public async Task<bool> IsGenreExistAsync(string name)
        {
            var res = await mediator.Send(new GetGenreByNameQuery()
            {
                Name = name
            });
             
            return res is null ? false : true;
        } 

        public async Task<int> RemoveGenreAsync(GenreDTO dto)
        {
            var res = await mediator.Send(new RemoveGenreCommand()
            {
                GenreDTO = dto
            });
            return res;
        }

        public async Task<int> UpdateGenreAsync(GenreDTO dto)
        {
            var res = await mediator.Send(new UpdateGenreCommand()
            {
                GenreDTO = dto
            });
            return res;
        }
    }
}
