using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastehub.Models
{
    public class Paste
    {
        public int Id { get; set; }
        public string PasteContent { get; set; } 
        public string SyntaxHighlight { get; set; }
        public string PasteExpiration { get; set; }
        public string PasteExposure { get; set; }
        public string PasteName { get; set; }
        public IEnumerable<SyntaxHighlight> SyntaxHighlights { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}