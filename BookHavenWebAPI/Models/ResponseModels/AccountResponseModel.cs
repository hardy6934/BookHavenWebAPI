using System.ComponentModel.DataAnnotations;

namespace BookHavenWebAPI.Models.ResponseModels
{
    public class AccountResponseModel
    { 
        public string Email { get; set; } 
        public string PasswordHash { get; set; } 
        public string FullName { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Position { get; set; }
        public string? PictureWebPath { get; set; }
    }
}
