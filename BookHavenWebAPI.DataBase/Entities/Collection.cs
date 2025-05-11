

using BookHavenWebAPI.Database.Entities;

namespace BookHavenWebAPI.DataBase.Entities
{
    public class Collection : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }    

        public List<CollectionBook> CollectionBooks {  get; set; }
    }
}
