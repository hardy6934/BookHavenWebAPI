using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.DataBase.Entities;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;

namespace BookHavenWebAPI.MapperProfiles
{
    public class CollectionProfile: Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, CollectionDTO>();
            CreateMap<CollectionDTO, Collection>();

            CreateMap<CollectionDTO, CollectionRequestModel>();
            CreateMap<CollectionRequestModel, CollectionDTO>();

            CreateMap<CollectionDTO, CollectionResponseModel>()
                .ForMember(model => model.BookResponseModels, opt => opt.MapFrom(ent => ent.CollectionBookDTOs));
            CreateMap<CollectionResponseModel, CollectionDTO>();
        }
    }
}
