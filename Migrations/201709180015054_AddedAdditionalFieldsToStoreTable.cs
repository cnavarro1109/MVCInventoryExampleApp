namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdditionalFieldsToStoreTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Description", c => c.String());
            AddColumn("dbo.Stores", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "IsActive");
            DropColumn("dbo.Stores", "Description");
        }
    }
}
