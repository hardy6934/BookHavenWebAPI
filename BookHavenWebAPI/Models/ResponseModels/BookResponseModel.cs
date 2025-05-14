namespace BookHavenWebAPI.Models.ResponseModels
{
    public class BookResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } 

        public int GenreId { get; set; }
    }
}
