namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeModificanCamposDeTask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExecutionControl", "ConfigurationId", "dbo.ClientConfiguration");
            DropForeignKey("dbo.ExecutionControl", "TaskId", "dbo.ServiceTask");
            DropIndex("dbo.ExecutionControl", new[] { "ConfigurationId" });
            DropIndex("dbo.ExecutionControl", new[] { "TaskId" });
            AddColumn("dbo.ExecutionControl", "Client", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.ExecutionControl", "Task", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.ExecutionControl", "ConfigurationId");
            DropColumn("dbo.ExecutionControl", "TaskId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExecutionControl", "TaskId", c => c.Guid(nullable: false));
            AddColumn("dbo.ExecutionControl", "ConfigurationId", c => c.Guid(nullable: false));
            DropColumn("dbo.ExecutionControl", "Task");
            DropColumn("dbo.ExecutionControl", "Client");
            CreateIndex("dbo.ExecutionControl", "TaskId");
            CreateIndex("dbo.ExecutionControl", "ConfigurationId");
            AddForeignKey("dbo.ExecutionControl", "TaskId", "dbo.ServiceTask", "TaskId", cascadeDelete: true);
            AddForeignKey("dbo.ExecutionControl", "ConfigurationId", "dbo.ClientConfiguration", "ConfigurationId", cascadeDelete: true);
        }
    }
}
