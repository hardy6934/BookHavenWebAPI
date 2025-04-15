﻿ 

namespace BookHaven.Core.DataTransferObjects
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string? PictureWebPath { get; set; }
    }
}
