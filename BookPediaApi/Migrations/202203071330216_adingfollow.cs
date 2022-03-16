namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adingfollow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foollows", "followingUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Foollows", "followingUserDisplayName", c => c.String());
            AddColumn("dbo.Foollows", "followingUserEmail", c => c.String());
            AddColumn("dbo.Foollows", "followingUserPhotoURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foollows", "followingUserPhotoURL");
            DropColumn("dbo.Foollows", "followingUserEmail");
            DropColumn("dbo.Foollows", "followingUserDisplayName");
            DropColumn("dbo.Foollows", "followingUserId");
        }
    }
}
