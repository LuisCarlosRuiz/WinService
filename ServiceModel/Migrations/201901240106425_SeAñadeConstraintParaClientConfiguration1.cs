namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeAñadeConstraintParaClientConfiguration1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ClientConfiguration", "ClientName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClientConfiguration", new[] { "ClientName" });
        }
    }
}
