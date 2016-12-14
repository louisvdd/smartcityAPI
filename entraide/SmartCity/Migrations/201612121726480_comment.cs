namespace SmartCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Id", "dbo.DoServices");
            DropIndex("dbo.Comments", new[] { "Id" });
            AddColumn("dbo.DoServices", "CommentDescription", c => c.String());
            AddColumn("dbo.DoServices", "Rating", c => c.Double(nullable: false));
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CommentDescription = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.DoServices", "Rating");
            DropColumn("dbo.DoServices", "CommentDescription");
            CreateIndex("dbo.Comments", "Id");
            AddForeignKey("dbo.Comments", "Id", "dbo.DoServices", "Id");
        }
    }
}
