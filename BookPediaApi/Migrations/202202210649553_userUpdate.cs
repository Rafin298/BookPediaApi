namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "displayName", c => c.String());
            AddColumn("dbo.Users", "date", c => c.String());
            AddColumn("dbo.Users", "photoUrl", c => c.String());
            DropColumn("dbo.Users", "firstName");
            DropColumn("dbo.Users", "surName");
            DropColumn("dbo.Users", "datee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "datee", c => c.String());
            AddColumn("dbo.Users", "surName", c => c.String());
            AddColumn("dbo.Users", "firstName", c => c.String());
            DropColumn("dbo.Users", "photoUrl");
            DropColumn("dbo.Users", "date");
            DropColumn("dbo.Users", "displayName");
        }
    }
}
