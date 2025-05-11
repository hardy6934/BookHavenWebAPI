
using BookHavenWebAPI.Database.Entities;

namespace BookHavenWebAPI.DataBase.Entities
{
    public class CollectionBook : IBaseEntity
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
