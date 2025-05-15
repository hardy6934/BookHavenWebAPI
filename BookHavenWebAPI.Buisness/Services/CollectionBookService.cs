using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Commands.BookCommands;
using BookHavenWebAPI.CQS.Commands.CollectionBookCommands;
using BookHavenWebAPI.CQS.Queries.CollectionBookQueries;
using MediatR;

namespace BookHavenWebAPI.Buisness.Services
{
    public class CollectionBookService : ICollectionBookService
    {
        private readonly IMediator mediator; 
        public CollectionBookService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<int> CreateCollectionBookAsync(CollectionBookDTO dto)
        {
            var res = await mediator.Send(new CreateCollectionBookCommand(){
                CollectionBookDTO = dto
            });
            return res;
        }

        public async Task<CollectionBookDTO> GetCollectionBookByIdAsnyc(int id, int accountId)
        {
            var res = await mediator.Send(new GetCollectionBookByIdQuery()
            {
                Id = id,
                AccountId = accountId
            });
            return res;
        }

        public async Task<bool> IsCollectionBookExistAsync(int bookId, int collectionId)
        {
            var res = await mediator.Send(new IsCollectionBookExistQuery()
            {
                BookId = bookId,
                CollectionId = collectionId
            });
            return res;
        }
         
        public async Task<List<CollectionBookDTO>> GetAllCollectionBooksInColectionForSearchAsnyc(string name, int collectionId, int accountId)
        {
            var res = await mediator.Send(new GetAllCollectionBooksInColectionForSearchQuery()
            {
                Name = name,
                AccountId = accountId,
                CollectionId = collectionId
            });
            return res;
        } 

        public async Task<List<CollectionBookDTO>> GetAllCollectionBooksInColectionAsnyc(int collectionId, int accountId)
        {
            var res = await mediator.Send(new GetAllCollectionBooksInColectionQuery()
            {
                AccountId = accountId,
                CollectionId = collectionId
            });
            return res;
        }

        public async Task<int> RemoveCollectionBookAsync(CollectionBookDTO dto)
        {
            var res = await mediator.Send(new RemoveCollectionBookCommand()
            {
                CollectionBookDTO = dto
            });
            return res;
        }

        public async Task<int> UpdateCollectionBookAsync(CollectionBookDTO dto)
        {
            var res = await mediator.Send(new UpdateCollectionBookCommand()
            {
                CollectionBookDTO = dto
            });
            return res;
        }
    }
}
