namespace CSharpEgitimKampi301.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class efmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductStock");
        }
    }
}
