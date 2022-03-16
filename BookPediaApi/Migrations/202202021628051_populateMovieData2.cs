namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovieData2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BOOKS(bookName,author) VALUES('golpo','Robin')");
        }
        
        public override void Down()
        {
        }
    }
}
