using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastehub.Constants
{
    public static class PasteExposure
    {
        public static IEnumerable<string> Exposure = new List<string>()
        {
            "Public",
            "Unlisted",
            "Private"
        };
    }
}