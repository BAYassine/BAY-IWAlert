namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dangers", "Disease_Id", "dbo.Diseases");
            DropIndex("dbo.Dangers", new[] { "Disease_Id" });
            DropColumn("dbo.Dangers", "Disease_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dangers", "Disease_Id", c => c.Int());
            CreateIndex("dbo.Dangers", "Disease_Id");
            AddForeignKey("dbo.Dangers", "Disease_Id", "dbo.Diseases", "Id");
        }
    }
}
