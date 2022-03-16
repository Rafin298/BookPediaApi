namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yoss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        blogTitle = c.String(),
                        blogDetails = c.String(),
                        blogcoverImageURL = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropTable("dbo.Blogs");
        }
    }
}
