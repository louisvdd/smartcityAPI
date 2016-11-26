namespace SmartCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BugTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Street", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "Number");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
