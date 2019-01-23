// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Filter Transaccion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Filter Transaccion
	/// </summary>
	[Table("FilterTransaccion")]
	public class FilterTransaccion
	{
		/// <summary>
		/// Gets or sets the filter identifier.
		/// </summary>
		/// <value>
		/// The filter identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("FilterId")]
		public int FilterId { get; set; }

		/// <summary>
		/// Gets or sets the movimientos desde.
		/// </summary>
		/// <value>
		/// The movimientos desde.
		/// </value>
		[Column("MovimientosDesde", TypeName = "datetime")]
		public DateTime MovimientosDesde { get; set; }

		/// <summary>
		/// Gets or sets the movimientos hasta.
		/// </summary>
		/// <value>
		/// The movimientos hasta.
		/// </value>
		[Column("MovimientosHasta", TypeName = "datetime")]
		public DateTime MovimientosHasta { get; set; }

		/// <summary>
		/// Gets or sets the configuration identifier.
		/// </summary>
		/// <value>
		/// The configuration identifier.
		/// </value>
		[Column("ConfigurationId", TypeName ="uniqueidentifier")]
		public Guid ConfigurationId { get; set; }

		/// <summary>
		/// Gets or sets the client configuration.
		/// </summary>
		/// <value>
		/// The client configuration.
		/// </value>
		[ForeignKey("ConfigurationId")]
		public ClientConfiguration ClientConfiguration { get; set; }
	}
}
