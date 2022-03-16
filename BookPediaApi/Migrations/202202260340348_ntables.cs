namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "email", c => c.String());
            AddColumn("dbo.Inventories", "rating", c => c.Single(nullable: false));
            AddColumn("dbo.Inventories", "like", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "like");
            DropColumn("dbo.Inventories", "rating");
            DropColumn("dbo.Inventories", "email");
        }
    }
}
