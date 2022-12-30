namespace Nike_vn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnApprIDToPrdctSize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSizes", "ApparelId", c => c.Long());
            CreateIndex("dbo.ProductSizes", "ApparelId");
            AddForeignKey("dbo.ProductSizes", "ApparelId", "dbo.Apparels", "ApparelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSizes", "ApparelId", "dbo.Apparels");
            DropIndex("dbo.ProductSizes", new[] { "ApparelId" });
            DropColumn("dbo.ProductSizes", "ApparelId");
        }
    }
}
