namespace DarehService.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useru : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Clients");
            DropIndex("dbo.Clients", "UserNameIndex");
            DropIndex("dbo.Clients", new[] { "CorrespondenceAddress_Id" });
            DropIndex("dbo.Clients", new[] { "RegisteredAddress_Id" });
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clients", "ApplicationType", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Clients", "RefreshTokenLifeTime", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "RegisterDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "LastLogOnDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "CorrespondenceAddress_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Clients", "RegisteredAddress_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Clients", "CorrespondenceAddress_Id");
            CreateIndex("dbo.Clients", "RegisteredAddress_Id");
            DropColumn("dbo.Clients", "EmailConfirmed");
            DropColumn("dbo.Clients", "PasswordHash");
            DropColumn("dbo.Clients", "SecurityStamp");
            DropColumn("dbo.Clients", "PhoneNumberConfirmed");
            DropColumn("dbo.Clients", "TwoFactorEnabled");
            DropColumn("dbo.Clients", "LockoutEndDateUtc");
            DropColumn("dbo.Clients", "LockoutEnabled");
            DropColumn("dbo.Clients", "AccessFailedCount");
            DropColumn("dbo.Clients", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Clients", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Clients", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "SecurityStamp", c => c.String());
            AddColumn("dbo.Clients", "PasswordHash", c => c.String());
            AddColumn("dbo.Clients", "EmailConfirmed", c => c.Boolean(nullable: false));
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Clients", new[] { "RegisteredAddress_Id" });
            DropIndex("dbo.Clients", new[] { "CorrespondenceAddress_Id" });
            AlterColumn("dbo.Clients", "RegisteredAddress_Id", c => c.Guid());
            AlterColumn("dbo.Clients", "CorrespondenceAddress_Id", c => c.Guid());
            AlterColumn("dbo.Clients", "LastLogOnDate", c => c.DateTime());
            AlterColumn("dbo.Clients", "RegisterDate", c => c.DateTime());
            AlterColumn("dbo.Clients", "Surname", c => c.String());
            AlterColumn("dbo.Clients", "FirstName", c => c.String());
            AlterColumn("dbo.Clients", "RefreshTokenLifeTime", c => c.Int());
            AlterColumn("dbo.Clients", "Active", c => c.Boolean());
            AlterColumn("dbo.Clients", "ApplicationType", c => c.Int());
            AlterColumn("dbo.Clients", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Clients", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Clients", "Email", c => c.String(maxLength: 256));
            DropTable("dbo.AspNetUsers");
            CreateIndex("dbo.Clients", "RegisteredAddress_Id");
            CreateIndex("dbo.Clients", "CorrespondenceAddress_Id");
            CreateIndex("dbo.Clients", "UserName", unique: true, name: "UserNameIndex");
            RenameTable(name: "dbo.Clients", newName: "AspNetUsers");
        }
    }
}
