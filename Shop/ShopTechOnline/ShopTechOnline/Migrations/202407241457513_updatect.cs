﻿namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatect : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategory", "Alias", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategory", "Alias", c => c.String(maxLength: 150));
        }
    }
}
