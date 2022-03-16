namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggNj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "writerName", c => c.String());
            DropColumn("dbo.Inventories", "like");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "like", c => c.Int(nullable: false));
            DropColumn("dbo.Inventories", "writerName");
        }
    }
}
