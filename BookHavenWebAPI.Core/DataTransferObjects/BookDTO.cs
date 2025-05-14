

namespace BookHavenWebAPI.Core.DataTransferObjects
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } 

        public int GenreId { get; set; }
        public GenreDTO GenreDTO { get; set; }

        public List<CollectionBookDTO> CollectionBookDTOs { get; set; }
    }
}
