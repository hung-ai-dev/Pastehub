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
    }
}