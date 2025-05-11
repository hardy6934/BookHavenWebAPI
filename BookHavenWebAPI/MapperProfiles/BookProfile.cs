using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;

namespace BookHavenWebAPI.MapperProfiles
{
    public class BookProfile: Profile
    {
        public BookProfile() {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

            CreateMap<BookDTO, BookRequestModel>();
            CreateMap<BookRequestModel, BookDTO>();

            CreateMap<BookDTO, BookResponseModel>();
            CreateMap<BookResponseModel, BookDTO>();
        }
    }
}
