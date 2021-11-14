namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Albumv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Albums", "DiscontPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "DiscontPrice");
            DropColumn("dbo.Albums", "Discount");
        }
    }
}
