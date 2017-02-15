using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastehub.Constants
{
    public static class PasteExpiration
    {
        public static IEnumerable<string> Expiration = new List<string>()
        {
            "Never",
            "10 Minutes",
            "1 Day",
            "1 Week",
            "1 Month"
        };

        public static TimeSpan ToTimeSpan(string expiration)
        {
            switch (expiration)
            {
                case "10 Minutes":
                    return new TimeSpan(0, 10, 0);
                case "1 Day":
                    return new TimeSpan(1, 0, 0, 0);
                case "1 Week":
                    return new TimeSpan(7, 0, 0, 0);
                case "1 Month":
                    return new TimeSpan(30, 0, 0, 0);
                default:
                    return new TimeSpan(0, 0, 0, 0);
            }
        }
    }
}