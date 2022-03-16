namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "postId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "id", cascadeDelete: true);
            DropColumn("dbo.Comments", "userName");
            DropColumn("dbo.Comments", "userEmail");
            DropColumn("dbo.Comments", "photoURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "photoURL", c => c.String());
            AddColumn("dbo.Comments", "userEmail", c => c.String());
            AddColumn("dbo.Comments", "userName", c => c.String());
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.Comments", "postId");
            DropColumn("dbo.Comments", "UserId");
        }
    }
}
