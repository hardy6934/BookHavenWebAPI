using AutoMapper;
using BookHaven.Core.DataTransferObjects;
using BookHaven.Database.Entities;

namespace BookHaven.MapperProfiles
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        { 
            CreateMap<Account, AccountDTO>().ReverseMap();  
        }
    }
}
