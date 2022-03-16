namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdatedSql : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users(firstName,surName,email,password,datee,gender) VALUES('Rafu','Khan','yoyo@gmail.com','1234','1999-02-18','Male')");
        }
        
        public override void Down()
        {
        }
    }
}
