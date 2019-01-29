// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Soary Context type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ServiceModel.Entities.Soari
{
	public class SoaryContext : DbContext
	{

		public SoaryContext(string connString) : base(connString)
		{
			var adapter = (IObjectContextAdapter)this;
			var objectContext = adapter.ObjectContext;
			objectContext.CommandTimeout = int.MaxValue;
		}

		/// <summary>
		/// Gets or sets the nit.
		/// </summary>
		/// <value>
		/// The nit.
		/// </value>
		public DbSet<Nit> Nit { get; set; }

		/// <summary>
		/// Gets or sets the actividad economica.
		/// </summary>
		/// <value>
		/// The actividad economica.
		/// </value>
		public DbSet<ActividadEconomica> ActividadEconomica { get; set; }

		/// <summary>
		/// Gets or sets the agencia.
		/// </summary>
		/// <value>
		/// The agencia.
		/// </value>
		public DbSet<Agencia> Agencia { get; set; }

		/// <summary>
		/// Gets or sets the ciudad.
		/// </summary>
		/// <value>
		/// The ciudad.
		/// </value>
		public DbSet<Ciudad> Ciudad { get; set; }

		/// <summary>
		/// Gets or sets the departamento.
		/// </summary>
		/// <value>
		/// The departamento.
		/// </value>
		public DbSet<Departamento> Departamento { get; set; }

		/// <summary>
		/// Gets or sets the estado civil.
		/// </summary>
		/// <value>
		/// The estado civil.
		/// </value>
		public DbSet<EstadoCivil> EstadoCivil { get; set; }

		/// <summary>
		/// Gets or sets the genero.
		/// </summary>
		/// <value>
		/// The genero.
		/// </value>
		public DbSet<Genero> Genero { get; set; }

		/// <summary>
		/// Gets or sets the jornada laboral.
		/// </summary>
		/// <value>
		/// The jornada laboral.
		/// </value>
		public DbSet<JornadaLaboral> JornadaLaboral { get; set; }

		/// <summary>
		/// Gets or sets the nivel estudio.
		/// </summary>
		/// <value>
		/// The nivel estudio.
		/// </value>
		public DbSet<NivelEstudio> NivelEstudio { get; set; }

		/// <summary>
		/// Gets or sets the ocupacion.
		/// </summary>
		/// <value>
		/// The ocupacion.
		/// </value>
		public DbSet<Ocupacion> Ocupacion { get; set; }

		/// <summary>
		/// Gets or sets the pais.
		/// </summary>
		/// <value>
		/// The pais.
		/// </value>
		public DbSet<Pais> Pais { get; set; }

		/// <summary>
		/// Gets or sets the sector economico.
		/// </summary>
		/// <value>
		/// The sector economico.
		/// </value>
		public DbSet<SectorEconomico> SectorEconomico { get; set; }

		/// <summary>
		/// Gets or sets the tipo contrato.
		/// </summary>
		/// <value>
		/// The tipo contrato.
		/// </value>
		public DbSet<TipoContrato> TipoContrato { get; set; }

		/// <summary>
		/// Gets or sets the tipo identificacion.
		/// </summary>
		/// <value>
		/// The tipo identificacion.
		/// </value>
		public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }

		/// <summary>
		/// Gets or sets the ahorro.
		/// </summary>
		/// <value>
		/// The ahorro.
		/// </value>
		public DbSet<Ahorro> Ahorro { get; set; }

		/// <summary>
		/// Gets or sets the aporte.
		/// </summary>
		/// <value>
		/// The aporte.
		/// </value>
		public DbSet<Aporte> Aporte { get; set; }

		/// <summary>
		/// Gets or sets the credito.
		/// </summary>
		/// <value>
		/// The credito.
		/// </value>
		public DbSet<Credito> Credito { get; set; }

		/// <summary>
		/// Gets or sets the estado ahorro.
		/// </summary>
		/// <value>
		/// The estado ahorro.
		/// </value>
		public DbSet<EstadoAhorro> EstadoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the tipo ahorro.
		/// </summary>
		/// <value>
		/// The tipo ahorro.
		/// </value>
		public DbSet<TipoAhorro> TipoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the tipo aporte.
		/// </summary>
		/// <value>
		/// The tipo aporte.
		/// </value>
		public DbSet<TipoAporte> TipoAporte { get; set; }

		/// <summary>
		/// Gets or sets the tipo cuota.
		/// </summary>
		/// <value>
		/// The tipo cuota.
		/// </value>
		public DbSet<TipoCuota> TipoCuota { get; set; }

		/// <summary>
		/// Gets or sets the tipo garantia.
		/// </summary>
		/// <value>
		/// The tipo garantia.
		/// </value>
		public DbSet<TipoGarantia> TipoGarantia { get; set; }

		/// <summary>
		/// Gets or sets the tipo modalidad.
		/// </summary>
		/// <value>
		/// The tipo modalidad.
		/// </value>
		public DbSet<TipoModalidad> TipoModalidad { get; set; }

		/// <summary>
		/// Gets or sets the canal.
		/// </summary>
		/// <value>
		/// The canal.
		/// </value>
		public DbSet<Canal> Canal { get; set; }

		/// <summary>
		/// Gets or sets the tipo producto.
		/// </summary>
		/// <value>
		/// The tipo producto.
		/// </value>
		public DbSet<TipoProducto> TipoProducto { get; set; }

		/// <summary>
		/// Gets or sets the tipo transaccion.
		/// </summary>
		/// <value>
		/// The tipo transaccion.
		/// </value>
		public DbSet<TipoTransaccion> TipoTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the transacciones.
		/// </summary>
		/// <value>
		/// The transacciones.
		/// </value>
		public DbSet<Transacciones> Transacciones { get; set; }
	}
}
