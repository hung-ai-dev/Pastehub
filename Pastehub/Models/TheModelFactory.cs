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
        private IPastehubRepository _repo;

        public TheModelFactory(IPastehubRepository repo)
        {
            _repo = repo;
        }

        public PasteViewModel CreatePaste(Paste paste)
        {
            PasteViewModel pasteViewModel = new PasteViewModel()
            {
                Id = paste.Id,
                CreatedDateTime = paste.CreatedDateTime,
                PasteContent =  paste.PasteContent,
                PasteExpiration = paste.PasteExpiration,
                PasteExposure = paste.PasteExposure,
                PasteName = paste.PasteName,
                SyntaxHighlight = _repo.GetSyntaxDisplay(paste.SyntaxHighlight),
                Hits = paste.Hits
            };

            return pasteViewModel;
        }
    }
}