namespace DarehService.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "CorrespondenceAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "RegisteredAddress_Id", "dbo.Addresses");
            DropIndex("dbo.Clients", new[] { "CorrespondenceAddress_Id" });
            DropIndex("dbo.Clients", new[] { "RegisteredAddress_Id" });
            AddColumn("dbo.Clients", "Secret", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.AspNetUsers", "RegisterDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "LastLogOnDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "CorrespondenceAddress_Id", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "RegisteredAddress_Id", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "CorrespondenceAddress_Id");
            CreateIndex("dbo.AspNetUsers", "RegisteredAddress_Id");
           
            DropColumn("dbo.Clients", "FirstName");
            DropColumn("dbo.Clients", "SecondName");
            DropColumn("dbo.Clients", "Surname");
            DropColumn("dbo.Clients", "PhoneNumber");
            DropColumn("dbo.Clients", "Email");
            DropColumn("dbo.Clients", "RegisterDate");
            DropColumn("dbo.Clients", "LastLogOnDate");
            DropColumn("dbo.Clients", "UserName");
            DropColumn("dbo.Clients", "Password");
            DropColumn("dbo.Clients", "ConfirmPassword");
            DropColumn("dbo.Clients", "CorrespondenceAddress_Id");
            DropColumn("dbo.Clients", "RegisteredAddress_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "RegisteredAddress_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Clients", "CorrespondenceAddress_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Clients", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Clients", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Clients", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "LastLogOnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "Email", c => c.String());
            AddColumn("dbo.Clients", "PhoneNumber", c => c.String());
            AddColumn("dbo.Clients", "Surname", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "SecondName", c => c.String());
            AddColumn("dbo.Clients", "FirstName", c => c.String(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "RegisteredAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUsers", "CorrespondenceAddress_Id", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "RegisteredAddress_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "CorrespondenceAddress_Id" });
            DropColumn("dbo.AspNetUsers", "RegisteredAddress_Id");
            DropColumn("dbo.AspNetUsers", "CorrespondenceAddress_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "LastLogOnDate");
            DropColumn("dbo.AspNetUsers", "RegisterDate");
            DropColumn("dbo.AspNetUsers", "ConfirmPassword");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Clients", "Name");
            DropColumn("dbo.Clients", "Secret");
            CreateIndex("dbo.Clients", "RegisteredAddress_Id");
            CreateIndex("dbo.Clients", "CorrespondenceAddress_Id");
            AddForeignKey("dbo.Clients", "RegisteredAddress_Id", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "CorrespondenceAddress_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
