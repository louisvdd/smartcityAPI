namespace SmartCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class augu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GetServices", "serviceGet_Id", "dbo.Services");
            DropForeignKey("dbo.GetServices", "userGet_Id", "dbo.AspNetUsers");
            DropIndex("dbo.GetServices", new[] { "serviceGet_Id" });
            DropIndex("dbo.GetServices", new[] { "userGet_Id" });
            DropTable("dbo.GetServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GetServices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        serviceGet_Id = c.Long(nullable: false),
                        userGet_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.GetServices", "userGet_Id");
            CreateIndex("dbo.GetServices", "serviceGet_Id");
            AddForeignKey("dbo.GetServices", "userGet_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GetServices", "serviceGet_Id", "dbo.Services", "Id", cascadeDelete: true);
        }
    }
}
