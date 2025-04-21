namespace BookHavenWebAPI.Models.ResponseModels
{
    public class TokenResponseModel
    {
        public string AccesToken { get; set; } 
        public int AccountId { get; set; }
        public DateTime TokenExp { get; set; }
        public Guid RefreshToken { get; set; }
    }
}
