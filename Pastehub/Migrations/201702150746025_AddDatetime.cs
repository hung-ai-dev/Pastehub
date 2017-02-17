namespace Pastehub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pastes", "CreatedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pastes", "CreatedDateTime");
        }
    }
}
