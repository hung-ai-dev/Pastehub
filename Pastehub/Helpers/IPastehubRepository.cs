using System.Collections.Generic;
using Pastehub.Models;

namespace Pastehub.Helpers
{
    public interface IPastehubRepository
    {
        Paste GetPasteWithId(int id);
        IEnumerable<Paste> GetPastes(string userId);
        IEnumerable<Paste> GetPublicPastes();
        void GetPasteAlive(IEnumerable<Paste> pastes);
        void AddPaste(Paste newPaste);
        IEnumerable<SyntaxHighlight> GetSyntax();
        string GetSyntaxDisplay(string syntax);
        void DeletePaste(int id);
    }
}