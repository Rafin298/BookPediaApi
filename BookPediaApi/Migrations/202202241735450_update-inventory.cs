namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateinventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "postTitle", c => c.String());
            AddColumn("dbo.Inventories", "bookURL", c => c.String());
            AddColumn("dbo.Inventories", "blogPost", c => c.String());
            AddColumn("dbo.Inventories", "save", c => c.String());
            AddColumn("dbo.Inventories", "category", c => c.String());
            DropColumn("dbo.Inventories", "title");
            DropColumn("dbo.Inventories", "bookDriveUrl");
            DropColumn("dbo.Inventories", "blogDetails");
            DropColumn("dbo.Inventories", "coverImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "coverImageUrl", c => c.String());
            AddColumn("dbo.Inventories", "blogDetails", c => c.String());
            AddColumn("dbo.Inventories", "bookDriveUrl", c => c.String());
            AddColumn("dbo.Inventories", "title", c => c.String());
            DropColumn("dbo.Inventories", "category");
            DropColumn("dbo.Inventories", "save");
            DropColumn("dbo.Inventories", "blogPost");
            DropColumn("dbo.Inventories", "bookURL");
            DropColumn("dbo.Inventories", "postTitle");
        }
    }
}
