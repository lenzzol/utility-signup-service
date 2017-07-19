using System;

namespace UtilitySignupService.Models
{
    public class ServiceAddress
    {
        public int ServiceId {get; set;}
        public int AcnId {get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}