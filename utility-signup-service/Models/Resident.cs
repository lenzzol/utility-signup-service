using System;

namespace UtilitySignupService.Models
{
    public class Resident
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Ssn { get; set; }
    }
}