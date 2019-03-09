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
		/// Gets or sets the mail configuration.
		/// </summary>
		/// <value>
		/// The mail configuration.
		/// </value>
		public DbSet<MailConfiguration> MailConfiguration { get; set; }

		/// <summary>
		/// Gets or sets the service task.
		/// </summary>
		/// <value>
		/// The service task.
		/// </value>
		public DbSet<ServiceTask> ServiceTask { get; set; }

		/// <summary>
		/// Gets or sets the user admin.
		/// </summary>
		/// <value>
		/// The user admin.
		/// </value>
		public DbSet<UserAdmin> UserAdmin { get; set; }

		/// <summary>
		/// Gets or sets the scheduler.
		/// </summary>
		/// <value>
		/// The scheduler.
		/// </value>
		public DbSet<Scheduler> Scheduler { get; set; }

		/// <summary>
		/// This method is called when the model for a derived context has been initialized, but
		/// before the model has been locked down and used to initialize the context.  The default
		/// implementation of this method does nothing, but it can be overridden in a derived class
		/// such that the model can be further configured before it is locked down.
		/// </summary>
		/// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
		/// <remarks>
		/// Typically, this method is called only once when the first instance of a derived context
		/// is created.  The model for that context is then cached and is for all further instances of
		/// the context in the app domain.  This caching can be disabled by setting the ModelCaching
		/// property on the given ModelBuidler, but note that this can seriously degrade performance.
		/// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
		/// classes directly.
		/// </remarks>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FilterBalance>().Property(p => p.SaldosMayores).HasPrecision(18, 2);

			modelBuilder.Entity<FilterProducto>().Property(p => p.SaldosMayores).HasPrecision(18, 2);

			//modelBuilder.Entity<ClientConfiguration>().HasIndex(u => u.JobId).IsUnique();
			//modelBuilder.Entity<ClientConfiguration>().HasIndex(u => u.ClientName).IsUnique();

			//modelBuilder.Entity<UserAdmin>().HasIndex(u => u.UserCode).IsUnique();

			//modelBuilder.Entity<Scheduler>().HasIndex(u => u.Consecutive).IsUnique();
		}
	}
}
