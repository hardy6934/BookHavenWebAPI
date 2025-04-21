

namespace BookHavenWebAPI.Core.DataTransferObjects
{
    public class RefreshTokenDTO
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public DateTime CreationDateTimeUTC { get; set; }
        public string DeviceName { get; set; }

        public int AccountId { get; set; }
        public AccountDTO AccountDTO { get; set; }
    }
}
