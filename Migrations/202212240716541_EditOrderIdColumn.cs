namespace Nike_vn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderIdColumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AddColumn("dbo.Orders", "OrderId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OrderId");
            DropColumn("dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Id", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.Orders");
            DropColumn("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.Orders", "Id");
        }
    }
}
