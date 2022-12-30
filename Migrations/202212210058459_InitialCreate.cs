namespace Nike_vn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apparels",
                c => new
                    {
                        ApparelId = c.Long(nullable: false, identity: true),
                        ApparelName = c.String(),
                    })
                .PrimaryKey(t => t.ApparelId);
            
            CreateTable(
                "dbo.ProductGenders",
                c => new
                    {
                        ProductGenderId = c.Long(nullable: false, identity: true),
                        ProductGenderName = c.String(),
                    })
                .PrimaryKey(t => t.ProductGenderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Int(),
                        ProductDescription = c.String(),
                        UrlImage = c.String(),
                        ProductGenderId = c.Long(),
                        ApparelId = c.Long(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Apparels", t => t.ApparelId)
                .ForeignKey("dbo.ProductGenders", t => t.ProductGenderId)
                .Index(t => t.ProductGenderId)
                .Index(t => t.ApparelId);
            
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        ProductSizeId = c.Long(nullable: false, identity: true),
                        ProductSizeName = c.String(),
                    })
                .PrimaryKey(t => t.ProductSizeId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ProductId = c.Long(nullable: false),
                        ProductSizeId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ProductSizeId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductSizes", t => t.ProductSizeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductSizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "ProductSizeId", "dbo.ProductSizes");
            DropForeignKey("dbo.Stores", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductGenderId", "dbo.ProductGenders");
            DropForeignKey("dbo.Products", "ApparelId", "dbo.Apparels");
            DropIndex("dbo.Stores", new[] { "ProductSizeId" });
            DropIndex("dbo.Stores", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ApparelId" });
            DropIndex("dbo.Products", new[] { "ProductGenderId" });
            DropTable("dbo.Stores");
            DropTable("dbo.ProductSizes");
            DropTable("dbo.Products");
            DropTable("dbo.ProductGenders");
            DropTable("dbo.Apparels");
        }
    }
}
