namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CategoryID_Id", "dbo.Categories");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropIndex("dbo.Courses", new[] { "CategoryID_Id" });
            RenameColumn(table: "dbo.Courses", name: "Category_Id", newName: "CategoryID");
            AlterColumn("dbo.Courses", "CategoryID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Courses", "CategoryID");
            AddForeignKey("dbo.Courses", "CategoryID", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "CategoryID_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CategoryID_Id", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            AlterColumn("dbo.Courses", "CategoryID", c => c.Byte());
            RenameColumn(table: "dbo.Courses", name: "CategoryID", newName: "Category_Id");
            CreateIndex("dbo.Courses", "CategoryID_Id");
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Courses", "CategoryID_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
