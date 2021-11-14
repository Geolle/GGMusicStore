namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Albumv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "DiscountPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Albums", "DiscontPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "DiscontPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Albums", "DiscountPrice");
        }
    }
}
