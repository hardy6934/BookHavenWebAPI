using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Models.ResponseModels
{
    public class CollectionResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int AccountId { get; set; } 

        public List<BookResponseModel> BookResponseModels { get; set; }
    }
}
