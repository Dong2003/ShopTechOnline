namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Alias", c => c.String());
            AddColumn("dbo.New", "Alias", c => c.String());
            AddColumn("dbo.Post", "Alias", c => c.String());
            AddColumn("dbo.Product", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Alias");
            DropColumn("dbo.Post", "Alias");
            DropColumn("dbo.New", "Alias");
            DropColumn("dbo.Category", "Alias");
        }
    }
}
