namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeAñadeUserAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAdmin",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        UserCode = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        Name = c.String(maxLength: 200, unicode: false),
                        Mail = c.String(maxLength: 200, unicode: false),
                        State = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserCode, unique: true);
            
            AlterColumn("dbo.MailConfiguration", "Port", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserAdmin", new[] { "UserCode" });
            AlterColumn("dbo.MailConfiguration", "Port", c => c.String(maxLength: 50, unicode: false));
            DropTable("dbo.UserAdmin");
        }
    }
}
