namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeModificaMailConfiguration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MailConfiguration", "EnableSsl", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MailConfiguration", "EnableSsl");
        }
    }
}
