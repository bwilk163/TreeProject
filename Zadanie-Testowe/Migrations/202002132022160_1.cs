namespace Zadanie_Testowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreeElements",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Value = c.String(),
                        ParentId = c.Guid(),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TreeElements");
        }
    }
}
