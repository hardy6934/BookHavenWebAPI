using System.ComponentModel.DataAnnotations;

namespace BookHaven.Models.RequestModels
{
    public class AccountRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string PasswordHash { get; set; }
        [Required]
        public string FullName { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Position { get; set; }
        public string? PictureWebPath { get; set; }
    }
}
