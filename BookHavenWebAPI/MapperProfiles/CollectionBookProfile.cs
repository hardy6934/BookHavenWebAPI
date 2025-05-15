using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.DataBase.Entities;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;

namespace BookHavenWebAPI.MapperProfiles
{
    public class CollectionBookProfile: Profile
    {
        public CollectionBookProfile() {

            CreateMap<CollectionBook, CollectionBookDTO>()
                .ForMember(model => model.BookDTO, opt => opt.MapFrom(dto => dto.Book))
                .ForMember(model => model.CollectionDTO, opt => opt.MapFrom(dto => dto.Collection)); 
            CreateMap<CollectionBookDTO, CollectionBook>();

            CreateMap<CollectionBookDTO, CollectionBookRequestModel>();
            CreateMap<CollectionBookRequestModel, CollectionBookDTO>();

            CreateMap<CollectionBookDTO, CollectionBookResponseModel>()
                .ForMember(model=>model.BookResponseModel, opt=>opt.MapFrom(dto=>dto.BookDTO))
                .ForMember(model=>model.CollectionResponseModel, opt=>opt.MapFrom(dto=>dto.CollectionDTO));
            CreateMap<CollectionBookResponseModel, CollectionBookDTO>();
            
        }
    }
}
