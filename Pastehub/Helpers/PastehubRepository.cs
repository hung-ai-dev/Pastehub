using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pastehub.Models;
using Microsoft.AspNet.Identity;
using Pastehub.Constants;

namespace Pastehub.Helpers
{
    public class PastehubRepository : IPastehubRepository
    {
        private ApplicationDbContext _context;

        public PastehubRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Paste GetPasteWithId(int id)
        {
            Paste paste = _context.Pastes.FirstOrDefault(p => p.Id == id);
            paste.Hits++;
            _context.SaveChanges();
            return paste;
        }

        public IEnumerable<Paste> GetPastes(string userId)
        {
            if (userId == null)
                return null;
            
            var pastes = _context.Pastes.Where(p => p.UserId == userId).ToList();
            GetPasteAlive(pastes);
            pastes = _context.Pastes.Where(p => p.UserId == userId).ToList();
            return pastes;
        }

        public IEnumerable<Paste> GetPublicPastes()
        {
            var pastes = _context.Pastes.Where(p => String.Compare(p.PasteExposure, "public", true) == 0).ToList();
            GetPasteAlive(pastes);
            pastes = _context.Pastes.Where(p => String.Compare(p.PasteExposure, "public", true) == 0).ToList();
            return pastes;
        }

        public void GetPasteAlive(IEnumerable<Paste> pastes)
        {
            foreach (var paste in pastes)
            {
                if (String.Compare(paste.PasteExpiration, "Never") != 0 &&
                    TimeSpan.Compare(DateTime.Now.Subtract(paste.CreatedDateTime), PasteExpiration.ToTimeSpan(paste.PasteExpiration)) == 1)
                {
                    var obj = _context.Pastes.FirstOrDefault(p => p.Id == paste.Id);
                    if (obj != null)
                        _context.Pastes.Remove(obj);
                }
            }
            _context.SaveChanges();
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

        public void DeletePaste(int id)
        {
            try
            {
                var paste = GetPasteWithId(id);
                _context.Pastes.Remove(paste);
                _context.SaveChanges();
            }
            catch (Exception)
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
            var obj = _context.SyntaxHighlights.Single(s => s.Name == syntax);
            return obj.NameDisplay;
        }
    }
}