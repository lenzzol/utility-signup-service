using System;

namespace UtilitySignupService.Models
{
    public class Enrollment
    {
        public Resident Resident { get; set; }
        public ServiceAddress ServiceAddress { get; set; }

        public Property Property { get; set; }

        public User CreatedBy { get; set; }

        public int ServiceRequestTypeId { get; set; }

        public string ServiceRequestType
        {
            get
            {
                return Constants.ServiceRequestType[this.ServiceRequestTypeId];
            }
        }

        public DateTime DesiredStart { get; set; }

        public string DesiredStartDate
        {
            get
            {
                return this.DesiredStart.ToString("d");
            }
        }

        public DateTime Created { get; set; }

        public string CreatedDate
        {
            get
            {
                return this.Created.ToString("d");
            }
        }

    }
}