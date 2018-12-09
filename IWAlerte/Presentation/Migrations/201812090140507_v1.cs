namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
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
                        Name = c.String(),
                        Description = c.String(),
                        Picture = c.String(),
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
                        Description = c.String(),
                        Picture = c.String(),
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Place_Country = c.String(),
                        Place_Town = c.String(),
                        Cin = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disease_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Disease_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Dangers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCorrect = c.Boolean(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        Notified = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Disease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Dangers", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Alertes", "Danger_Id", "dbo.Dangers");
            DropForeignKey("dbo.Alertes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Alertes", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Treatements", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Symptoms", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Diseases", "Statistics_Id", "dbo.Statistics");
            DropForeignKey("dbo.Prevention_Control", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Diagnostics", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Advices", "Disease_Id", "dbo.Diseases");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Dangers", new[] { "Disease_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Notifications", new[] { "Disease_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Treatements", new[] { "Disease_Id" });
            DropIndex("dbo.Symptoms", new[] { "Disease_Id" });
            DropIndex("dbo.Prevention_Control", new[] { "Disease_Id" });
            DropIndex("dbo.Diagnostics", new[] { "Disease_Id" });
            DropIndex("dbo.Diseases", new[] { "Statistics_Id" });
            DropIndex("dbo.Alertes", new[] { "Danger_Id" });
            DropIndex("dbo.Alertes", new[] { "User_Id" });
            DropIndex("dbo.Alertes", new[] { "Disease_Id" });
            DropIndex("dbo.Advices", new[] { "Disease_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Dangers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
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
