namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeAñadeConstraintParaClientConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ClientConfiguration", "JobId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClientConfiguration", new[] { "JobId" });
        }
    }
}
