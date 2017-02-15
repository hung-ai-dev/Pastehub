using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pastehub.Helpers;
using Pastehub.ViewModels;

namespace Pastehub.Models
{
    public class TheModelFactory
    {
        private PastehubRepository _repo;

        public TheModelFactory()
        {
            _repo = new PastehubRepository();
        }

        public PasteViewModel CreatePaste(Paste paste)
        {
            PasteViewModel pasteViewModel = new PasteViewModel()
            {
                Id = paste.Id,
                PasteContent =  paste.PasteContent,
                PasteExpiration = paste.PasteExpiration,
                PasteExposure = paste.PasteExposure,
                PasteName = paste.PasteName,
                SyntaxHighlight = _repo.GetSyntaxDisplay(paste.SyntaxHighlight)
            };

            return pasteViewModel;
        }
    }
}