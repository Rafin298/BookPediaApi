namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventoryClassAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        title = c.String(),
                        bookDriveUrl = c.String(),
                        authorName = c.String(),
                        blogDetails = c.String(),
                        coverImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inventories");
        }
    }
}
