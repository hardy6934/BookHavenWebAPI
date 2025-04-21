using AutoMapper;
using BookHaven.Core.DataTransferObjects;
using BookHaven.Database.Entities;
using BookHaven.Models.RequestModels;
using BookHaven.Models.ResponseModels;

namespace BookHaven.MapperProfiles
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        { 
            CreateMap<Account, AccountDTO>();  
            CreateMap<AccountDTO, Account>();  

            CreateMap<AccountDTO, AccountRequestModel>();  
            CreateMap<AccountRequestModel, AccountDTO>();  

            CreateMap<AccountResponseModel, AccountDTO>();  
            CreateMap<AccountDTO, AccountResponseModel>();  
        }
    }
}
