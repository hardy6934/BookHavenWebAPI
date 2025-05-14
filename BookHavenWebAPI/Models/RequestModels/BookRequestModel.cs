
namespace BookHavenWebAPI.Models.RequestModels
{
    public class BookRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } 

        public int GenreId { get; set; }
    }
}
