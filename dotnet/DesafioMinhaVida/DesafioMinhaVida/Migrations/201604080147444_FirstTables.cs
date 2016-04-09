namespace DesafioMinhaVida.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElectricGuitars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        SKU = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ElectricGuitars");
        }
    }
}
