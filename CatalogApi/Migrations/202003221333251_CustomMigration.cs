namespace CatalogApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCatalog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemCategory = c.String(),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        ItemValue = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemCatalog");
        }
    }
}
