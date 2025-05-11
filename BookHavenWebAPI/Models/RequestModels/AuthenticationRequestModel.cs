using System.ComponentModel.DataAnnotations;

namespace BookHavenWebAPI.Models.RequestModels
{
    public class AuthenticationRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required] 
        [MinLength(5)]
        public string Password { get; set; }
    }
}
