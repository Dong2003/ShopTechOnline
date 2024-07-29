namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.New", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Post", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "IsActive");
            DropColumn("dbo.Post", "IsActive");
            DropColumn("dbo.New", "IsActive");
            DropColumn("dbo.Category", "IsActive");
        }
    }
}
