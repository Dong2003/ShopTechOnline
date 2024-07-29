namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2507 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Image = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImage", "ProductID", "dbo.Product");
            DropIndex("dbo.ProductImage", new[] { "ProductID" });
            DropTable("dbo.ProductImage");
        }
    }
}
