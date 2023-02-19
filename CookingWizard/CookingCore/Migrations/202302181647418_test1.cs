namespace CookingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipe", "Author_ID", "dbo.User");
            DropIndex("dbo.Recipe", new[] { "Author_ID" });
            AddColumn("dbo.Recipe", "Author_ID1", c => c.Int());
            AlterColumn("dbo.Recipe", "Author_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipe", "Author_ID1");
            AddForeignKey("dbo.Recipe", "Author_ID1", "dbo.User", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "Author_ID1", "dbo.User");
            DropIndex("dbo.Recipe", new[] { "Author_ID1" });
            AlterColumn("dbo.Recipe", "Author_ID", c => c.Int());
            DropColumn("dbo.Recipe", "Author_ID1");
            CreateIndex("dbo.Recipe", "Author_ID");
            AddForeignKey("dbo.Recipe", "Author_ID", "dbo.User", "ID");
        }
    }
}
