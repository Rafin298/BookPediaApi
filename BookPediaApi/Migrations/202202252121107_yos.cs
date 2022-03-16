namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bookName = c.String(),
                        bookURL = c.String(),
                        coverImageURL = c.String(),
                        category = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "UserId", "dbo.Users");
            DropIndex("dbo.Books", new[] { "UserId" });
            DropTable("dbo.Books");
        }
    }
}
