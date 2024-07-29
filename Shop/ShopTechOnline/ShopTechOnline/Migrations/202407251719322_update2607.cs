namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2607 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "PrcieSale", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "PrcieSale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
