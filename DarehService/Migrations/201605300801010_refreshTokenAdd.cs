namespace DarehService.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refreshTokenAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StreetName = c.String(nullable: false),
                        LocalNumber = c.String(),
                        StreetNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Community = c.String(nullable: false),
                        County = c.String(nullable: false),
                        Province = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RefreshTokens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 50),
                        ClientId = c.String(nullable: false, maxLength: 50),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApplicationType", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Active", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "RefreshTokenLifeTime", c => c.Int());
            AddColumn("dbo.AspNetUsers", "AllowedOrigin", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "RegisterDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "LastLogOnDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "CorrespondenceAddress_Id", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "RegisteredAddress_Id", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "CorrespondenceAddress_Id");
            CreateIndex("dbo.AspNetUsers", "RegisteredAddress_Id");
            //AddForeignKey("dbo.AspNetUsers", "CorrespondenceAddress_Id", "dbo.Addresses", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.AspNetUsers", "RegisteredAddress_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.AspNetUsers", "RegisteredAddress_Id", "dbo.Addresses");
            //DropForeignKey("dbo.AspNetUsers", "CorrespondenceAddress_Id", "dbo.Addresses");
            //DropIndex("dbo.AspNetUsers", new[] { "RegisteredAddress_Id" });
            //DropIndex("dbo.AspNetUsers", new[] { "CorrespondenceAddress_Id" });
            //DropColumn("dbo.AspNetUsers", "RegisteredAddress_Id");
            //DropColumn("dbo.AspNetUsers", "CorrespondenceAddress_Id");
            //DropColumn("dbo.AspNetUsers", "Discriminator");
            //DropColumn("dbo.AspNetUsers", "LastLogOnDate");
            //DropColumn("dbo.AspNetUsers", "RegisterDate");
            //DropColumn("dbo.AspNetUsers", "Surname");
            //DropColumn("dbo.AspNetUsers", "SecondName");
            //DropColumn("dbo.AspNetUsers", "FirstName");
            //DropColumn("dbo.AspNetUsers", "AllowedOrigin");
            //DropColumn("dbo.AspNetUsers", "RefreshTokenLifeTime");
            //DropColumn("dbo.AspNetUsers", "Active");
            //DropColumn("dbo.AspNetUsers", "ApplicationType");
            //DropColumn("dbo.AspNetUsers", "ConfirmPassword");
            //DropColumn("dbo.AspNetUsers", "Password");
            //DropTable("dbo.RefreshTokens");
            //DropTable("dbo.Addresses");
        }
    }
}
