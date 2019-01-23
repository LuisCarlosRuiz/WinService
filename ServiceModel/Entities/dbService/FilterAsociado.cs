// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Filter Asociado type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Filter Asociado
	/// </summary>
	[Table("FilterAsociado")]
	public class FilterAsociado
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
		/// Gets or sets the fecha actualizacion.
		/// </summary>
		/// <value>
		/// The fecha actualizacion.
		/// </value>
		[Column("FechaActualizacion", TypeName = "datetime")]
		public DateTime FechaActualizacion { get; set; }

		/// <summary>
		/// Gets or sets the configuration identifier.
		/// </summary>
		/// <value>
		/// The configuration identifier.
		/// </value>
		[Column("ConfigurationId", TypeName = "uniqueidentifier")]
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
