namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Inventories", "Stores_Id", c => c.Int());
            CreateIndex("dbo.Inventories", "Stores_Id");
            AddForeignKey("dbo.Inventories", "Stores_Id", "dbo.Stores", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Stores_Id", "dbo.Stores");
            DropIndex("dbo.Inventories", new[] { "Stores_Id" });
            DropColumn("dbo.Inventories", "Stores_Id");
            DropTable("dbo.Stores");
        }
    }
}
