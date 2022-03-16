namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColFollowAdd938PM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foollows", "follow", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foollows", "follow");
        }
    }
}
