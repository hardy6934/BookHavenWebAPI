using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Commands.CollectionCommands;
using BookHavenWebAPI.CQS.Queries.CollectionQueires;
using BookHavenWebAPI.Database.Entities;
using MediatR;
using System.Xml.Linq;

namespace BookHavenWebAPI.Buisness.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IMediator mediator;

        public CollectionService(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public async Task<int> CreateCollectionAsync(CollectionDTO dto)
        {
            var res = await mediator.Send(new CreateCollectionCommand()
            {
                CollectionDTO = dto
            });
            return res;
        }

        public async Task<List<CollectionDTO>> GetAllCollectionsAsnyc(int accountId)
        {
            var res = await mediator.Send(new GetAllCollectionsForAccountQuery()
            {
                AccountId = accountId
            });
            return res;
        }

        public async Task<List<CollectionDTO>> GetAllCollectionsForSearchAsnyc(string name, int accountId)
        {
            var res = await mediator.Send(new GetCollectionByNameForAccountForSearchQuery()
            {
                AccountId = accountId,
                Name = name
            });
            return res;
        }

        public async Task<CollectionDTO> GetCollectionByIdAsnyc(int id, int accountId)
        {
            var res = await mediator.Send(new GetCollectionByIdForAccountQuery()
            {
                AccountId = accountId,
                Id = id
            });
            return res;
        }

        public async Task<bool> IsCollectionExistAsync(string name, int accountId)
        {
            var res = await mediator.Send(new GetCollectionByNameForAccountQuery()
            {
                AccountId = accountId,
                Name = name
            });
            return res is not null ? true : false;
        }

        public async Task<int> RemoveCollectionAsync(CollectionDTO dto)
        {
            var res = await mediator.Send(new RemoveCollectionCommand()
            {
                CollectionDTO = dto
            });
            return res;
        }

        public async Task<int> UpdateCollectionAsync(CollectionDTO dto)
        {
            var res = await mediator.Send(new UpdateCollectionCommand()
            {
                CollectionDTO = dto
            });
            return res;
        }
    }
}
