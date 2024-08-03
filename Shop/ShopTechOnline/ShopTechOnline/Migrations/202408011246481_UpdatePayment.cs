namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "TypePayment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "TypePayment");
        }
    }
}
