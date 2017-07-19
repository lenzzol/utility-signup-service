using System;

namespace UtilitySignupService.Models
{
    public class EmailSettings
    {
        public string InternalEmail { get; set; }

        public string InternalContact { get; set; }
        public string ExternalTemplate { get; set; }
        public string InternalTemplate { get; set; }
        public string PropertyTemplate { get; set; }
    }
}