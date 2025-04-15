 

namespace BookHaven.Database.Entities
{
    public class RefreshToken: IBaseEntity
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public DateTime CreationDateTimeUTC { get; set; }
        public string DeviceName { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
