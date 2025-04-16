using AutoMapper;
using BookHaven.Core.Abstractions;
using BookHaven.Core.DataTransferObjects;
using BookHaven.CQS.Queries;
using MediatR; 

namespace BookHaven.Buisness.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AccountService(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public async Task<AccountDTO> GetAccountByEmailAsync(string email)
        {
            var dto = await mediator.Send(new GetAccountByEmailQuery()
            {
                Email = email
            });
            return dto;
        }

        public Task<AccountDTO> GetAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
