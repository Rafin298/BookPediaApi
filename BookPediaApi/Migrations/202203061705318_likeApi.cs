namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likeApi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "city", c => c.String());
            AddColumn("dbo.Users", "work", c => c.String());
            AddColumn("dbo.Inventories", "authorPhotoUrl", c => c.String());
            DropColumn("dbo.Inventories", "rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "rating", c => c.Single(nullable: false));
            DropColumn("dbo.Inventories", "authorPhotoUrl");
            DropColumn("dbo.Users", "work");
            DropColumn("dbo.Users", "city");
        }
    }
}
