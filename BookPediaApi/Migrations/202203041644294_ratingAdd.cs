namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        inventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Inventories", t => t.inventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.inventoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "inventoryId", "dbo.Inventories");
            DropIndex("dbo.Ratings", new[] { "inventoryId" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropTable("dbo.Ratings");
        }
    }
}
