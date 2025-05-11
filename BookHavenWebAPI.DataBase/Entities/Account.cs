
using BookHavenWebAPI.DataBase.Entities;

namespace BookHavenWebAPI.Database.Entities
{
    public class Account: IBaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Position { get; set; }
        public string? PictureWebPath { get; set; }

        public List<Collection> Collections { get; set; }
    }
}
