namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatectgy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.ProductCategory", "Icon", c => c.String(maxLength: 250));
            AlterColumn("dbo.ProductCategory", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.ProductCategory", "SeoDescription", c => c.String(maxLength: 550));
            AlterColumn("dbo.ProductCategory", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategory", "SeoKeywords", c => c.String());
            AlterColumn("dbo.ProductCategory", "SeoDescription", c => c.String());
            AlterColumn("dbo.ProductCategory", "SeoTitle", c => c.String());
            AlterColumn("dbo.ProductCategory", "Icon", c => c.String());
            DropColumn("dbo.ProductCategory", "Alias");
        }
    }
}
