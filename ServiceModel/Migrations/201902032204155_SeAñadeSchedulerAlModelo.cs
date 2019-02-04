namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeAñadeSchedulerAlModelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Scheduler",
                c => new
                    {
                        SchedulerId = c.Guid(nullable: false, identity: true),
                        Consecutive = c.Int(nullable: false),
                        TaskName = c.String(maxLength: 150, unicode: false),
                        ClientId = c.String(maxLength: 5, unicode: false),
                        Status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.SchedulerId)
                .Index(t => t.Consecutive, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Scheduler", new[] { "Consecutive" });
            DropTable("dbo.Scheduler");
        }
    }
}
