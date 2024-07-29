namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update25007 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ProductImage_ID", "dbo.ProductImage");
            DropForeignKey("dbo.ProductImage", "Product_ID", "dbo.Product");
            DropIndex("dbo.Product", new[] { "ProductImage_ID" });
            DropIndex("dbo.ProductImage", new[] { "ProductID" });
            DropIndex("dbo.ProductImage", new[] { "Product_ID" });
            DropColumn("dbo.ProductImage", "ProductID");
            RenameColumn(table: "dbo.ProductImage", name: "Product_ID", newName: "ProductID");
            AlterColumn("dbo.ProductImage", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductImage", "ProductID");
            AddForeignKey("dbo.ProductImage", "ProductID", "dbo.Product", "ID", cascadeDelete: true);
            DropColumn("dbo.Product", "ProductImage_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductImage_ID", c => c.Int());
            DropForeignKey("dbo.ProductImage", "ProductID", "dbo.Product");
            DropIndex("dbo.ProductImage", new[] { "ProductID" });
            AlterColumn("dbo.ProductImage", "ProductID", c => c.Int());
            RenameColumn(table: "dbo.ProductImage", name: "ProductID", newName: "Product_ID");
            AddColumn("dbo.ProductImage", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductImage", "Product_ID");
            CreateIndex("dbo.ProductImage", "ProductID");
            CreateIndex("dbo.Product", "ProductImage_ID");
            AddForeignKey("dbo.ProductImage", "Product_ID", "dbo.Product", "ID");
            AddForeignKey("dbo.Product", "ProductImage_ID", "dbo.ProductImage", "ID");
        }
    }
}
