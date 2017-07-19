using System;
using System.Collections.Generic;

namespace UtilitySignupService.Models
{
    public static class Constants
    {
        public static Dictionary<int, string> Roles = new Dictionary<int, string>()
        {
            {1, "Resident"},
            {2, "Property Manager"},
            {3, "CRR"},
        };

        public static Dictionary<int, string> ServiceRequestType = new Dictionary<int, string>()
        {
            {1, "Turn On"},
            {2, "Turn Off"},
            {3, "Establish Service"},
        };
    }

    public enum NotifyType
    {
        External,
        Internal,
        Property
    }
}