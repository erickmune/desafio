namespace DesafioMinhaVida.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ElectricGuitars", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.ElectricGuitars", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ElectricGuitars", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.ElectricGuitars", "Name", c => c.String(nullable: false));
        }
    }
}
