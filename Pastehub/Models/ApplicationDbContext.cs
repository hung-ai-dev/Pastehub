using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Pastehub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Paste> Pastes { get; set; }
        public DbSet<SyntaxHighlight> SyntaxHighlights { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}