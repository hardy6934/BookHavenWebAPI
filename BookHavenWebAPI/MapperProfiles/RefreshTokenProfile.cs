using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;

namespace BookHavenWebAPI.MapperProfiles
{
    public class RefreshTokenProfile: Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshToken, RefreshTokenDTO>();
            CreateMap<RefreshTokenDTO, RefreshToken>(); 
        }
    }
}
