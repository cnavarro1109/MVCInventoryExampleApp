namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreCategories");
        }
    }
}
