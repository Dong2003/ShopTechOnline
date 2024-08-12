namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesub1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subscribe", "Created");
            DropColumn("dbo.Subscribe", "ModifiledDate");
            DropColumn("dbo.Subscribe", "ModifierBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subscribe", "ModifierBy", c => c.String());
            AddColumn("dbo.Subscribe", "ModifiledDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Subscribe", "Created", c => c.String());
        }
    }
}
