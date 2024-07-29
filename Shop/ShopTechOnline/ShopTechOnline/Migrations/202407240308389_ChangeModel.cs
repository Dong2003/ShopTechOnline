namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Post", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.Post", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Post", "SeoTitle", c => c.String(maxLength: 350));
            AlterColumn("dbo.Post", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Post", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "Alias", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.Product", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Product", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "SeoKeywords", c => c.String());
            AlterColumn("dbo.Product", "SeoDescription", c => c.String());
            AlterColumn("dbo.Product", "SeoTitle", c => c.String());
            AlterColumn("dbo.Product", "Image", c => c.String());
            AlterColumn("dbo.Product", "ProductCode", c => c.String());
            AlterColumn("dbo.Product", "Alias", c => c.String());
            AlterColumn("dbo.Post", "SeoKeywords", c => c.String());
            AlterColumn("dbo.Post", "SeoDescription", c => c.String());
            AlterColumn("dbo.Post", "SeoTitle", c => c.String());
            AlterColumn("dbo.Post", "Image", c => c.String());
            AlterColumn("dbo.Post", "Alias", c => c.String());
        }
    }
}
