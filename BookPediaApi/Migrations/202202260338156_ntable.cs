namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usersaveds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        authorName = c.String(),
                        userMail = c.String(),
                        postTitle = c.String(),
                        type = c.String(),
                        bookURL = c.String(),
                        blogPost = c.String(),
                        save = c.String(),
                        category = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usersaveds");
        }
    }
}
