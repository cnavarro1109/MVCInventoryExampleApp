namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToStore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "OpenDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "OpenDate");
        }
    }
}
