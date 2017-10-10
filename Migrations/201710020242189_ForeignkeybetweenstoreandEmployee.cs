namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignkeybetweenstoreandEmployee : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Stores", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Stores", "EmployeeID");
            AddForeignKey("dbo.Stores", "EmployeeID", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Stores", new[] { "EmployeeID" });
            DropColumn("dbo.Stores", "EmployeeID");
        }
    }
}
