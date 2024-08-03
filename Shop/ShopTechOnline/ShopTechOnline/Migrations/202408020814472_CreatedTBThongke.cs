namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTBThongke : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statisticals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        SoLuongTruyCap = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Product", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ViewCount");
            DropTable("dbo.Statisticals");
        }
    }
}
