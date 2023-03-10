namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (4,'Development')");
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (5,'Business')");
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (6,'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
