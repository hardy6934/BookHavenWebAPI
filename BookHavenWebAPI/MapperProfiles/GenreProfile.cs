using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;

namespace BookHavenWebAPI.MapperProfiles
{
    public class GenreProfile: Profile
    {
        public GenreProfile() {
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();

            CreateMap<GenreDTO, GenreRequestModel>();
            CreateMap<GenreRequestModel, GenreDTO>();

            CreateMap<GenreDTO, GenreResponseModel>();
            CreateMap<GenreResponseModel, GenreDTO>();
        }
    }
}
