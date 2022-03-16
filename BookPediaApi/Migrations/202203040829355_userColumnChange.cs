namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userColumnChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usersaveds", "coverImageURL", c => c.String());
            DropColumn("dbo.Usersaveds", "save");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usersaveds", "save", c => c.String());
            DropColumn("dbo.Usersaveds", "coverImageURL");
        }
    }
}
