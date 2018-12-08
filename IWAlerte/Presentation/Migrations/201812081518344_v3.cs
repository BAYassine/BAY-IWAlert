namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.Alertes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                        Danger_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Dangers", t => t.Danger_Id)
                .Index(t => t.Disease_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Danger_Id);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Statistics_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statistics", t => t.Statistics_Id)
                .Index(t => t.Statistics_Id);
            
            CreateTable(
                "dbo.Diagnostics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.Prevention_Control",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.Treatements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Disease_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Dangers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alertes", "Danger_Id", "dbo.Dangers");
            DropForeignKey("dbo.Alertes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Alertes", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Treatements", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Symptoms", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Diseases", "Statistics_Id", "dbo.Statistics");
            DropForeignKey("dbo.Prevention_Control", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Diagnostics", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Advices", "Disease_Id", "dbo.Diseases");
            DropIndex("dbo.Notifications", new[] { "User_Id" });
            DropIndex("dbo.Notifications", new[] { "Disease_Id" });
            DropIndex("dbo.Treatements", new[] { "Disease_Id" });
            DropIndex("dbo.Symptoms", new[] { "Disease_Id" });
            DropIndex("dbo.Prevention_Control", new[] { "Disease_Id" });
            DropIndex("dbo.Diagnostics", new[] { "Disease_Id" });
            DropIndex("dbo.Diseases", new[] { "Statistics_Id" });
            DropIndex("dbo.Alertes", new[] { "Danger_Id" });
            DropIndex("dbo.Alertes", new[] { "User_Id" });
            DropIndex("dbo.Alertes", new[] { "Disease_Id" });
            DropIndex("dbo.Advices", new[] { "Disease_Id" });
            DropTable("dbo.Dangers");
            DropTable("dbo.Notifications");
            DropTable("dbo.Treatements");
            DropTable("dbo.Symptoms");
            DropTable("dbo.Statistics");
            DropTable("dbo.Prevention_Control");
            DropTable("dbo.Diagnostics");
            DropTable("dbo.Diseases");
            DropTable("dbo.Alertes");
            DropTable("dbo.Advices");
        }
    }
}
