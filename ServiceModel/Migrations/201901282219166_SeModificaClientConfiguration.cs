namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeModificaClientConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientConfiguration", "DBPassword", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.ClientConfiguration", "ServicePassword", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientConfiguration", "ServicePassword", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.ClientConfiguration", "DBPassword", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
