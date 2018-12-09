namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiseaseDanger_attributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diseases", "Name", c => c.String());
            AddColumn("dbo.Dangers", "ApprovedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Dangers", "Notified", c => c.Boolean(nullable: false));
            AddColumn("dbo.Dangers", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Dangers", "Disease_Id", c => c.Int());
            CreateIndex("dbo.Dangers", "Disease_Id");
            AddForeignKey("dbo.Dangers", "Disease_Id", "dbo.Diseases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dangers", "Disease_Id", "dbo.Diseases");
            DropIndex("dbo.Dangers", new[] { "Disease_Id" });
            DropColumn("dbo.Dangers", "Disease_Id");
            DropColumn("dbo.Dangers", "Date");
            DropColumn("dbo.Dangers", "Notified");
            DropColumn("dbo.Dangers", "ApprovedBy");
            DropColumn("dbo.Diseases", "Name");
        }
    }
}
