namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesub : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscribe", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribe", "Email", c => c.String());
        }
    }
}
