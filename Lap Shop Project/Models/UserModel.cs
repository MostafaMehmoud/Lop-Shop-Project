﻿using System.ComponentModel.DataAnnotations;

namespace Lap_Shop_Project.Models
{
    public class UserModel
    {
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl {  get; set; }
    }
}
