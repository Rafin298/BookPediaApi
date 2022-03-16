namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdatedv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "datee", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "datee", c => c.DateTime(nullable: false));
        }
    }
}
