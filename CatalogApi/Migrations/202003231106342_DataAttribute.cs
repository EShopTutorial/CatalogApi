namespace CatalogApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemCatalog", "ItemCategory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemCatalog", "ItemCategory", c => c.String());
        }
    }
}
