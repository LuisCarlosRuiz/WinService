namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeAñadeElObjetoMailConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailConfiguration",
                c => new
                    {
                        CuentaId = c.Guid(nullable: false, identity: true),
                        Host = c.String(maxLength: 50, unicode: false),
                        Port = c.String(maxLength: 50, unicode: false),
                        UseCredencials = c.Byte(nullable: false),
                        Mail = c.String(maxLength: 100, unicode: false),
                        Password = c.String(maxLength: 200, unicode: false),
                        State = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.CuentaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MailConfiguration");
        }
    }
}
