namespace DarehService.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CorrespondenceAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUsers", "RegisteredAddress_Id", "dbo.Addresses");
            AddForeignKey("dbo.AspNetUsers", "CorrespondenceAddress_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.AspNetUsers", "RegisteredAddress_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RegisteredAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUsers", "CorrespondenceAddress_Id", "dbo.Addresses");
            AddForeignKey("dbo.AspNetUsers", "RegisteredAddress_Id", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CorrespondenceAddress_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
