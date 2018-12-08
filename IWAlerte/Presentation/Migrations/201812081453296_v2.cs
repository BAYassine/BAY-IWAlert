namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Place_Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "Place_Town", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Place_Town");
            DropColumn("dbo.AspNetUsers", "Place_Country");
        }
    }
}
