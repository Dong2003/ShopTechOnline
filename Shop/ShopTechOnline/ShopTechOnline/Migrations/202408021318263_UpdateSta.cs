namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSta : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Statisticals", newName: "Statistical");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Statistical", newName: "Statisticals");
        }
    }
}
