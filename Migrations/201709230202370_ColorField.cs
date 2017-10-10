namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Color", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "Color");
        }
    }
}
