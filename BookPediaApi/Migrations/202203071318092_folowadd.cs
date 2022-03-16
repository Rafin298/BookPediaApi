namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class folowadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foollows",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foollows", "UserId", "dbo.Users");
            DropIndex("dbo.Foollows", new[] { "UserId" });
            DropTable("dbo.Foollows");
        }
    }
}
