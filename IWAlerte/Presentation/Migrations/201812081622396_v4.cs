namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diseases", "Name", c => c.String());
            AddColumn("dbo.Diseases", "Description", c => c.String());
            AddColumn("dbo.Diseases", "Picture", c => c.String());
            AddColumn("dbo.Symptoms", "Description", c => c.String());
            AddColumn("dbo.Symptoms", "Picture", c => c.String());
            AddColumn("dbo.AspNetUsers", "Cin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Cin");
            DropColumn("dbo.Symptoms", "Picture");
            DropColumn("dbo.Symptoms", "Description");
            DropColumn("dbo.Diseases", "Picture");
            DropColumn("dbo.Diseases", "Description");
            DropColumn("dbo.Diseases", "Name");
        }
    }
}
