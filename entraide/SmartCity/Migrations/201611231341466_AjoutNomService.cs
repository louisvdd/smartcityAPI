namespace SmartCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutNomService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "NameService", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "NameService");
        }
    }
}
