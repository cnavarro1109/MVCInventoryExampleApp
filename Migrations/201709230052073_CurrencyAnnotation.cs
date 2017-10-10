namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Inventories", "Description", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "Description", c => c.String());
            DropColumn("dbo.Inventories", "Price");
        }
    }
}
