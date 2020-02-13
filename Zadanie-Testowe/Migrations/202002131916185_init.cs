namespace Zadanie_Testowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreeElements",
                c => new
                    {
                        ParentId = c.Guid(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TreeElements");
        }
    }
}
