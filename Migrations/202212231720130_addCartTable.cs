namespace Nike_vn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Long(nullable: false),
                        ProductSizeId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.ProductId, t.ProductSizeId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductSizes", t => t.ProductSizeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductSizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductSizeId", "dbo.ProductSizes");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductSizeId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropTable("dbo.Carts");
        }
    }
}
