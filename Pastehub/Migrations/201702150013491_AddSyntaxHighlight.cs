namespace Pastehub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSyntaxHighlight : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SyntaxHighlights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NameDisplay = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SyntaxHighlights");
        }
    }
}
