using System;

namespace UtilitySignupService.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
    }
}