namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatements", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treatements", "Description");
        }
    }
}
