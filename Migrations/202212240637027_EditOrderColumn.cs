namespace Nike_vn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderColumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Orders", "Id");
        }
    }
}
