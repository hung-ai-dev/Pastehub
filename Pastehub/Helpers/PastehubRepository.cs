using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pastehub.Models;
using Microsoft.AspNet.Identity;

namespace Pastehub.Helpers
{
    public class PastehubRepository
    {
        private ApplicationDbContext _context;

        public PastehubRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Paste GetPasteWithId(int id)
        {
            Paste paste = _context.Pastes.FirstOrDefault(p => p.Id == id);
            return paste;
        }

        public IEnumerable<Paste> GetPastes(string userId)
        {
            if (userId == null)
                return null;

            var pastes = _context.Pastes.Where(p => p.UserId == userId).ToList();
            return pastes;
        }

        public IEnumerable<Paste> GetPublicPastes()
        {
            var pastes = _context.Pastes.Where(p => String.Compare(p.PasteExposure, "public", true) == 0).ToList();
            return pastes;
        }

        public void AddPaste(Paste newPaste)
        {
            try
            {
                _context.Pastes.Add(newPaste);
                _context.SaveChanges();
            }
            catch (Exception )
            {
                throw;
            }
        }

        public IEnumerable<SyntaxHighlight> GetSyntax()
        {
            var syntaxList = _context.SyntaxHighlights.ToList();
            return syntaxList;
        }

        public string GetSyntaxDisplay(string syntax)
        {
            return _context.SyntaxHighlights.Where(s => s.Name == syntax).Select(s => s.NameDisplay).ToString();
        }
    }
}