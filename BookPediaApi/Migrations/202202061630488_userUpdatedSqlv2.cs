namespace BookPediaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdatedSqlv2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users(firstName,surName,email,password,datee,gender) VALUES('Rafin','Khan','rafin@gmail.com','1234','1999-02-18','Male')");
            Sql("INSERT INTO Users(firstName,surName,email,password,datee,gender) VALUES('Tonmoy','Talukder','tonmoy@gmail.com','1234','1999-02-18','Male')");
            Sql("INSERT INTO Users(firstName,surName,email,password,datee,gender) VALUES('Mehnaj','Sultana','mehnaj@gmail.com','1234','1999-02-18','Male')");
        }
        
        public override void Down()
        {
        }
    }
}
