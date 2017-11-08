namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForeignKeyToStoreTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "CategoryID", c => c.Int(nullable: true));
            CreateIndex("dbo.Stores", "CategoryID");
            AddForeignKey("dbo.Stores", "CategoryID", "dbo.StoreCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "CategoryID", "dbo.StoreCategories");
            DropIndex("dbo.Stores", new[] { "CategoryID" });
            DropColumn("dbo.Stores", "CategoryID");
        }
    }
}
