namespace Shop_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShopImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "ShopImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shops", "ShopImg");
        }
    }
}
