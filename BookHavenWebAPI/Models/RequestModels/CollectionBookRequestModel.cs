
namespace BookHavenWebAPI.Models.RequestModels
{
    public class CollectionBookRequestModel
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public bool IsFavorite { get; set; }
        public string? CustomDescription { get; set; }
        public int BookId { get; set; } 
    }
}
