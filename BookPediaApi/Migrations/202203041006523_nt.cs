namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nt : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Usersaveds");
        }
        
        public override void Down()
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
                        coverImageURL = c.String(),
                        category = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
