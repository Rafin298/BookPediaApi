namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventoryUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "coverImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "coverImageURL");
        }
    }
}
