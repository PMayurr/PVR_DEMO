using System;
using System.ComponentModel.DataAnnotations;

namespace PVR.Models
{
    public class Users
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Role { get; set; }


    }
}