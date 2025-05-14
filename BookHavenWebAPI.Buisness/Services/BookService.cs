using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Commands.BookCommands;
using BookHavenWebAPI.CQS.Queries.BookQueires;
using MediatR;
using System.Xml.Linq;

namespace BookHavenWebAPI.Buisness.Services
{
    public class BookService : IBookService
    {
        private readonly IMediator mediator;

        public BookService(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public async Task<int> CreateBookAsync(BookDTO dto)
        {
            var res = await mediator.Send(new CreateBookCommand
            {
                dto = dto
            });
            return res;
        }

        public async Task<List<BookDTO>> GetAllBooksAsnyc()
        {
            var res = await mediator.Send(new GetAllBooksQuery
            { 
            });
            return res;
        }

        public async Task<List<BookDTO>> GetAllBooksForSearchAsnyc(string name)
        {
            var res = await mediator.Send(new GetBookByNameForSearchQuery
            {
                Name = name
            });
            return res;
        }

        public async Task<BookDTO> GetBookByIdAsnyc(int id)
        {
            var res = await mediator.Send(new GetBookByIdQuery
            {
                Id = id
            });
            return res;
        }

        public async Task<bool> IsBookExistAsync(string name)
        {
            var res = await mediator.Send(new GetBookByNameQuery
            {
                Name = name
            });
            
            return res is not null ? true : false;
        }

        public async Task<int> RemoveBookAsync(BookDTO dto)
        {
            var res = await mediator.Send(new RemoveBookCommand
            {
                dto = dto
            }); 
            return res;
        }

        public async Task<int> UpdateBookAsync(BookDTO dto)
        {
            var res = await mediator.Send(new UpdateBookCommand
            {
                dto = dto
            });
            return res;
        }
    }
}
