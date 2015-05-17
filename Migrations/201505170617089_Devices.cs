namespace Jarvis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Devices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identification = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Created = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeviceStatus");
        }
    }
}
