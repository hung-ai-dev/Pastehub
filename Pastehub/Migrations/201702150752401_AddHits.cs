namespace Pastehub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pastes", "Hits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pastes", "Hits");
        }
    }
}
