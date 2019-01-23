// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the de data base context type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using ServiceModel.Migrations;
	using System.Data.Entity;

	internal class DbServiceContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IntegradorRepositoryContext"/> class.
		/// </summary>
		public DbServiceContext()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbServiceContext, Configuration>());
		}

		/// <summary>
		/// Gets or sets the execution control.
		/// </summary>
		/// <value>
		/// The execution control.
		/// </value>
		public DbSet<ExecutionControl> ExecutionControl { get; set; }

		/// <summary>
		/// Gets or sets the client configuration.
		/// </summary>
		/// <value>
		/// The client configuration.
		/// </value>
		public DbSet<ClientConfiguration> ClientConfiguration { get; set; }

		/// <summary>
		/// Gets or sets the cuenta.
		/// </summary>
		/// <value>
		/// The cuenta.
		/// </value>
		public DbSet<Cuenta> Cuenta { get; set; }

		/// <summary>
		/// Gets or sets the filter asociado.
		/// </summary>
		/// <value>
		/// The filter asociado.
		/// </value>
		public DbSet<FilterAsociado> FilterAsociado { get; set; }

		/// <summary>
		/// Gets or sets the filter balance.
		/// </summary>
		/// <value>
		/// The filter balance.
		/// </value>
		public DbSet<FilterBalance> FilterBalance { get; set; }

		/// <summary>
		/// Gets or sets the filter producto.
		/// </summary>
		/// <value>
		/// The filter producto.
		/// </value>
		public DbSet<FilterProducto> FilterProducto { get; set; }

		/// <summary>
		/// Gets or sets the filter transaccion.
		/// </summary>
		/// <value>
		/// The filter transaccion.
		/// </value>
		public DbSet<FilterTransaccion> FilterTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the service task.
		/// </summary>
		/// <value>
		/// The service task.
		/// </value>
		public DbSet<ServiceTask> ServiceTask { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FilterBalance>().Property(p => p.SaldosMayores).HasPrecision(18, 2);

			modelBuilder.Entity<FilterProducto>().Property(p => p.SaldosMayores).HasPrecision(18, 2);
		}
	}
}
