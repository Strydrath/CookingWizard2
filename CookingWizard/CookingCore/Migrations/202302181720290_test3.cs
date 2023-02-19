namespace CookingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipe", "Author_ID", "dbo.User");
            DropIndex("dbo.Recipe", new[] { "Author_ID" });
            AlterColumn("dbo.Recipe", "Author_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipe", "Author_ID");
            AddForeignKey("dbo.Recipe", "Author_ID", "dbo.User", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "Author_ID", "dbo.User");
            DropIndex("dbo.Recipe", new[] { "Author_ID" });
            AlterColumn("dbo.Recipe", "Author_ID", c => c.Int());
            CreateIndex("dbo.Recipe", "Author_ID");
            AddForeignKey("dbo.Recipe", "Author_ID", "dbo.User", "ID");
        }
    }
}
