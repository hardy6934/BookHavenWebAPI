
namespace BookHavenWebAPI.Database.Entities
{
    public class Book: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool IsFavorite { get; set; }
        
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
