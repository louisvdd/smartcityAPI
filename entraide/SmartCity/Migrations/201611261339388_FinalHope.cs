namespace SmartCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalHope : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GetServices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        serviceGet_Id = c.Long(nullable: false),
                        userGet_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.serviceGet_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userGet_Id, cascadeDelete: true)
                .Index(t => t.serviceGet_Id)
                .Index(t => t.userGet_Id);
            
            AddColumn("dbo.Services", "serviceDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Services", "UserNeedService_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "DateInscription", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumGetService", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumServiceGive", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "UserNeedService_Id");
            AddForeignKey("dbo.Services", "UserNeedService_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GetServices", "userGet_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GetServices", "serviceGet_Id", "dbo.Services");
            DropForeignKey("dbo.Services", "UserNeedService_Id", "dbo.AspNetUsers");
            DropIndex("dbo.GetServices", new[] { "userGet_Id" });
            DropIndex("dbo.GetServices", new[] { "serviceGet_Id" });
            DropIndex("dbo.Services", new[] { "UserNeedService_Id" });
            DropColumn("dbo.AspNetUsers", "NumServiceGive");
            DropColumn("dbo.AspNetUsers", "NumGetService");
            DropColumn("dbo.AspNetUsers", "DateInscription");
            DropColumn("dbo.Services", "UserNeedService_Id");
            DropColumn("dbo.Services", "serviceDone");
            DropTable("dbo.GetServices");
        }
    }
}
