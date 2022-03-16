namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yo : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Books");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bookName = c.String(),
                        author = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
