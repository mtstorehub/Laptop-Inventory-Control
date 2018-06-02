namespace InventoryControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Stu_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Stu_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
        }
    }
}
