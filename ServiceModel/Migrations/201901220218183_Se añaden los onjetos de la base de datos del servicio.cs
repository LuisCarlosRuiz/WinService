namespace ServiceModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seañadenlosonjetosdelabasededatosdelservicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientConfiguration",
                c => new
                    {
                        ConfigurationId = c.Guid(nullable: false, identity: true),
                        JobId = c.String(maxLength: 4, unicode: false),
                        DBServerName = c.String(maxLength: 100, unicode: false),
                        DBName = c.String(maxLength: 50, unicode: false),
                        DBUser = c.String(maxLength: 50, unicode: false),
                        DBPassword = c.String(maxLength: 20, unicode: false),
                        ServiceUrl = c.String(maxLength: 200, unicode: false),
                        ServiceUser = c.String(maxLength: 20, unicode: false),
                        ServicePassword = c.String(maxLength: 20, unicode: false),
                        ServicedbPassword = c.String(maxLength: 20, unicode: false),
                        ClientName = c.String(maxLength: 100, unicode: false),
                        State = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ConfigurationId);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        CuentaId = c.Guid(nullable: false, identity: true),
                        CodigoCuenta = c.String(maxLength: 10, unicode: false),
                        NombreCuenta = c.String(maxLength: 200, unicode: false),
                        FiltroId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CuentaId)
                .ForeignKey("dbo.FilterBalance", t => t.FiltroId, cascadeDelete: true)
                .Index(t => t.FiltroId);
            
            CreateTable(
                "dbo.FilterBalance",
                c => new
                    {
                        FilterId = c.Guid(nullable: false, identity: true),
                        ConfiguracionId = c.Guid(nullable: false),
                        SaldosMayores = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ano = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilterId)
                .ForeignKey("dbo.ClientConfiguration", t => t.ConfiguracionId, cascadeDelete: true)
                .Index(t => t.ConfiguracionId);
            
            CreateTable(
                "dbo.ExecutionControl",
                c => new
                    {
                        ExecutionId = c.Guid(nullable: false, identity: true),
                        ExecutionDate = c.DateTime(nullable: false),
                        ConfigurationId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                        Log = c.String(maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.ExecutionId)
                .ForeignKey("dbo.ClientConfiguration", t => t.ConfigurationId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTask", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.ConfigurationId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.ServiceTask",
                c => new
                    {
                        TaskId = c.Guid(nullable: false, identity: true),
                        TaskName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
            CreateTable(
                "dbo.FilterAsociado",
                c => new
                    {
                        FilterId = c.Int(nullable: false, identity: true),
                        FechaActualizacion = c.DateTime(nullable: false),
                        ConfigurationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FilterId)
                .ForeignKey("dbo.ClientConfiguration", t => t.ConfigurationId, cascadeDelete: true)
                .Index(t => t.ConfigurationId);
            
            CreateTable(
                "dbo.FilterProducto",
                c => new
                    {
                        FilterId = c.Int(nullable: false, identity: true),
                        SaldosMayores = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConfigurationId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FilterId)
                .ForeignKey("dbo.ClientConfiguration", t => t.ConfigurationId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTask", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.ConfigurationId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.FilterTransaccion",
                c => new
                    {
                        FilterId = c.Int(nullable: false, identity: true),
                        MovimientosDesde = c.DateTime(nullable: false),
                        MovimientosHasta = c.DateTime(nullable: false),
                        ConfigurationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FilterId)
                .ForeignKey("dbo.ClientConfiguration", t => t.ConfigurationId, cascadeDelete: true)
                .Index(t => t.ConfigurationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilterTransaccion", "ConfigurationId", "dbo.ClientConfiguration");
            DropForeignKey("dbo.FilterProducto", "TaskId", "dbo.ServiceTask");
            DropForeignKey("dbo.FilterProducto", "ConfigurationId", "dbo.ClientConfiguration");
            DropForeignKey("dbo.FilterAsociado", "ConfigurationId", "dbo.ClientConfiguration");
            DropForeignKey("dbo.ExecutionControl", "TaskId", "dbo.ServiceTask");
            DropForeignKey("dbo.ExecutionControl", "ConfigurationId", "dbo.ClientConfiguration");
            DropForeignKey("dbo.Cuenta", "FiltroId", "dbo.FilterBalance");
            DropForeignKey("dbo.FilterBalance", "ConfiguracionId", "dbo.ClientConfiguration");
            DropIndex("dbo.FilterTransaccion", new[] { "ConfigurationId" });
            DropIndex("dbo.FilterProducto", new[] { "TaskId" });
            DropIndex("dbo.FilterProducto", new[] { "ConfigurationId" });
            DropIndex("dbo.FilterAsociado", new[] { "ConfigurationId" });
            DropIndex("dbo.ExecutionControl", new[] { "TaskId" });
            DropIndex("dbo.ExecutionControl", new[] { "ConfigurationId" });
            DropIndex("dbo.FilterBalance", new[] { "ConfiguracionId" });
            DropIndex("dbo.Cuenta", new[] { "FiltroId" });
            DropTable("dbo.FilterTransaccion");
            DropTable("dbo.FilterProducto");
            DropTable("dbo.FilterAsociado");
            DropTable("dbo.ServiceTask");
            DropTable("dbo.ExecutionControl");
            DropTable("dbo.FilterBalance");
            DropTable("dbo.Cuenta");
            DropTable("dbo.ClientConfiguration");
        }
    }
}
