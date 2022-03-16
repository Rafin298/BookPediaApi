namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "firstName", c => c.String());
            AddColumn("dbo.Users", "surName", c => c.String());
            AddColumn("dbo.Users", "datee", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "gender", c => c.String());
            DropColumn("dbo.Users", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "name", c => c.String());
            DropColumn("dbo.Users", "gender");
            DropColumn("dbo.Users", "datee");
            DropColumn("dbo.Users", "surName");
            DropColumn("dbo.Users", "firstName");
        }
    }
}
