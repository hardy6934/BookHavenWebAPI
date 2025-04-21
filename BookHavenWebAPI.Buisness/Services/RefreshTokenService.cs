using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;  
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using BookHavenWebAPI.CQS.Commands.RefreshTokenCommands;
using BookHavenWebAPI.CQS.Queries.RefreshTokenQueries;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.CQS.Queries.AccountQueries;

namespace Accessor.Buisness.Services
{
    public class RefreshTokenService : IRefreshTokenService
    { 
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public RefreshTokenService(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }


        public async Task<int> CreateRefreshTokenAsync(RefreshTokenDTO refreshTokenDTO)
        {
            int Id = await mediator.Send(new AddRefreshTokenCommand()
            {
                refreshTokenDTO = refreshTokenDTO
            });
            return Id;
        }

        public async Task<List<RefreshTokenDTO>> GetAllRefreshTokensForAccountAsNotrackingAsync(int accountId)
        {  
            var dtos = await mediator.Send(new GetAllRefreshTokensByAccountIdQuery()
            {
                AccountId = accountId
            });
             
            return dtos.Select(mapper.Map<RefreshTokenDTO>).ToList();
        }

        public async Task<RefreshTokenDTO> GetRefreshTokenByTokenAsNoTrackingAsync(Guid token)
        {
            var dto = await mediator.Send(new GetRefreshTokenByTokenQuery()
            {
                Token = token
            });
             
            return mapper.Map<RefreshTokenDTO>(dto);
        }

        public async Task<AccountDTO> GetAccountByRefreshTokensTokenAsNoTrackingAsync(Guid token)
        {
            var dto = await mediator.Send(new GetAccountByRefreshTokensTokenQuery()
            {
                Token = token
            });

            return mapper.Map<AccountDTO>(dto); 
        }

        public async Task<int> RemoveRangeRefreshTokenAsync(List<RefreshTokenDTO> refreshTokenDTOs)
        {
            int count = await mediator.Send(new RemoveRangeRefreshTokensCommand()
            {
                refreshTokenDTOs = refreshTokenDTOs
            });
            return count; 
        }

        public async Task<int> RemoveRefreshTokenAsync(RefreshTokenDTO refreshTokenDTO)
        {
            int count = await mediator.Send(new RemoveRefreshTokenCommand()
            {
                refreshTokenDTO = refreshTokenDTO
            });
            return count; 
        }
    }
}
