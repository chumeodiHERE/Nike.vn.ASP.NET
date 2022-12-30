namespace Nike_vn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSportRow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        SportId = c.Long(nullable: false, identity: true),
                        SportName = c.String(),
                    })
                .PrimaryKey(t => t.SportId);
            
            AddColumn("dbo.Products", "SportId", c => c.Long());
            CreateIndex("dbo.Products", "SportId");
            AddForeignKey("dbo.Products", "SportId", "dbo.Sports", "SportId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SportId", "dbo.Sports");
            DropIndex("dbo.Products", new[] { "SportId" });
            DropColumn("dbo.Products", "SportId");
            DropTable("dbo.Sports");
        }
    }
}
