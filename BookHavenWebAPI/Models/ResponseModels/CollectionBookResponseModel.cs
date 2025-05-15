using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Models.ResponseModels
{
    public class CollectionBookResponseModel
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public bool IsFavorite { get; set; }
        public string? CustomDescription { get; set; }
        public CollectionResponseModel CollectionResponseModel { get; set; }
        public int BookId { get; set; }
        public BookResponseModel BookResponseModel { get; set; }
    }
}
