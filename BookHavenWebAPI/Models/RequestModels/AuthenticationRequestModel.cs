using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookHavenWebAPI.Models.RequestModels
{
    public class AuthenticationRequestModel
    {
        [Required]
        [EmailAddress]
        [DefaultValue("qwe@gmail.com")]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]

        [DefaultValue("qwe@gmail.com")]
        public string Password { get; set; }
    }
}
