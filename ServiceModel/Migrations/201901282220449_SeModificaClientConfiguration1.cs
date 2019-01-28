namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeModificaClientConfiguration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientConfiguration", "ServicedbPassword", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientConfiguration", "ServicedbPassword", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
