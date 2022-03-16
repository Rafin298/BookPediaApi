namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floatAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "rating", c => c.Int(nullable: false));
        }
    }
}
