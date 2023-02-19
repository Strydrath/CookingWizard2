namespace CookingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Recipe", new[] { "Author_ID1" });
            DropColumn("dbo.Recipe", "Author_ID");
            RenameColumn(table: "dbo.Recipe", name: "Author_ID1", newName: "Author_ID");
            AlterColumn("dbo.Recipe", "Author_ID", c => c.Int());
            CreateIndex("dbo.Recipe", "Author_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Recipe", new[] { "Author_ID" });
            AlterColumn("dbo.Recipe", "Author_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Recipe", name: "Author_ID", newName: "Author_ID1");
            AddColumn("dbo.Recipe", "Author_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipe", "Author_ID1");
        }
    }
}
