namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Category", "SeoTitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.Category", "SeoDescription", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "SeoDescription", c => c.String());
            AlterColumn("dbo.Category", "SeoTitle", c => c.String());
            AlterColumn("dbo.Category", "Title", c => c.String());
        }
    }
}
