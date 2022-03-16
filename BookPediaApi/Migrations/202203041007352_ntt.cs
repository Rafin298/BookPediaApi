namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usersaveds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userEmail = c.String(),
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
            DropForeignKey("dbo.Usersaveds", "UserId", "dbo.Users");
            DropForeignKey("dbo.Usersaveds", "inventoryId", "dbo.Inventories");
            DropIndex("dbo.Usersaveds", new[] { "inventoryId" });
            DropIndex("dbo.Usersaveds", new[] { "UserId" });
            DropTable("dbo.Usersaveds");
        }
    }
}
