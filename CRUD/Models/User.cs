﻿namespace CRUD.Models
{
    public class User
    {
        public int UserId { get; set;  }
        public required string UserName { get; set; }
        public int MobileNo { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
