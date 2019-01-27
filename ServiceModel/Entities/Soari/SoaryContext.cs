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
	internal class SoaryContext : DbContext
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
	}
}
