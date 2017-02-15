using Pastehub.Models;

namespace Pastehub.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Pastehub.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Pastehub.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Pastehub.Models.ApplicationDbContext";
        }

        protected override void Seed(Pastehub.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.SyntaxHighlights.AddOrUpdate(
                s => s.Name,
                new SyntaxHighlight() { Name = "markup", NameDisplay = "Markup" },
                new SyntaxHighlight() { Name = "css", NameDisplay = "Css" },
                new SyntaxHighlight() { Name = "clike", NameDisplay = "CLike" },
                new SyntaxHighlight() { Name = "javascript", NameDisplay = "Javascript" },
                new SyntaxHighlight() { Name = "aspnet", NameDisplay = "Asp.NET" },
                new SyntaxHighlight() { Name = "c", NameDisplay = "C" },
                new SyntaxHighlight() { Name = "csharp", NameDisplay = "C#" },
                new SyntaxHighlight() { Name = "cpp", NameDisplay = "C++" },
                new SyntaxHighlight() { Name = "ruby", NameDisplay = "Ruby" },
                new SyntaxHighlight() { Name = "fsharp", NameDisplay = "F#" },
                new SyntaxHighlight() { Name = "git", NameDisplay = "Git" },
                new SyntaxHighlight() { Name = "go", NameDisplay = "Go" },
                new SyntaxHighlight() { Name = "http", NameDisplay = "Http" },
                new SyntaxHighlight() { Name = "java", NameDisplay = "Java" },
                new SyntaxHighlight() { Name = "json", NameDisplay = "JSon" },
                new SyntaxHighlight() { Name = "less", NameDisplay = "Les" },
                new SyntaxHighlight() { Name = "matlab", NameDisplay = "Matlab" },
                new SyntaxHighlight() { Name = "objectivec", NameDisplay = "Objective-C" },
                new SyntaxHighlight() { Name = "pascal", NameDisplay = "Pascal" },
                new SyntaxHighlight() { Name = "perl", NameDisplay = "Perl" },
                new SyntaxHighlight() { Name = "php", NameDisplay = "PHP" },
                new SyntaxHighlight() { Name = "prolog", NameDisplay = "Prolog" },
                new SyntaxHighlight() { Name = "python", NameDisplay = "Python" },
                new SyntaxHighlight() { Name = "r", NameDisplay = "R" },
                new SyntaxHighlight() { Name = "sass", NameDisplay = "SASS" },
                new SyntaxHighlight() { Name = "scss", NameDisplay = "SCSS" },
                new SyntaxHighlight() { Name = "scala", NameDisplay = "Scala" },
                new SyntaxHighlight() { Name = "sql", NameDisplay = "Sql" },
                new SyntaxHighlight() { Name = "swift", NameDisplay = "Swift" }
            );
        }
    }
}
