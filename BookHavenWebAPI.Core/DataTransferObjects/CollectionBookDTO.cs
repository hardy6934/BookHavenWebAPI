

namespace BookHavenWebAPI.Core.DataTransferObjects
{
    public class CollectionBookDTO
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public bool IsFavorite { get; set; }
        public string? CustomDescription { get; set; }
        public CollectionDTO CollectionDTO { get; set; }
        public int BookId { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
