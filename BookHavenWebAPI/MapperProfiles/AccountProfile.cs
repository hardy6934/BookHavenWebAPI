using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;

namespace BookHavenWebAPI.MapperProfiles
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
