using AutoMapper;
using BookHaven.Core.Abstractions;
using BookHaven.Core.DataTransferObjects;
using BookHaven.CQS.Commands;
using BookHaven.CQS.Queries;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace BookHaven.Buisness.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;

        public AccountService(IMapper mapper, IMediator mediator, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.configuration = configuration;
        }

        public async Task<AccountDTO> GetAccountByEmailAsync(string email)
        {
            var dto = await mediator.Send(new GetAccountByEmailQuery()
            {
                Email = email
            });
            return dto;
        }

        public async Task<AccountDTO> GetAccountByIdAsync(int Id)
        {
            var dto = await mediator.Send(new GetAccountByIdQuery()
            {
                Id = Id
            });
            return dto;
        }

        public async Task<int> CreateAccountAsync(AccountDTO dto)
        {
             
            dto.PasswordHash = CreateMd5(dto.PasswordHash); 

            int id = await mediator.Send(new AddAccountCommand()
            {
                accountDTO = dto
            });
            return id;
        }

        public async Task<bool> CheckUserPassword(AccountDTO dto)
        {
            try
            { 
                var dbAccount = await mediator.Send(new GetAccountByEmailQuery()
                {
                    Email = dto.Email
                });  

                if (dbAccount != null && CreateMd5(dto.PasswordHash.Trim()).Equals(dbAccount.PasswordHash))
                {
                    return true;
                }
                else
                    return false; 

            }
            catch (Exception)
            {
                throw;
            }
        }

        private string CreateMd5(string password)
        {
            try
            {
                var passwordSalt = configuration.GetSection("PasswordSalt");

                using MD5 md5 = MD5.Create();
                var inputBytes = System.Text.Encoding.UTF8.GetBytes(password + passwordSalt);
                var hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
