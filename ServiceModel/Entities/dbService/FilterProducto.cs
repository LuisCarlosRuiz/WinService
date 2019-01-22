// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Filter Producto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Filter Producto
	/// </summary>
	[Table("FilterProducto")]
	public class FilterProducto
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
		/// Gets or sets the saldos mayores.
		/// </summary>
		/// <value>
		/// The saldos mayores.
		/// </value>
		[Column("SaldosMayores", TypeName = "decimal")]
		public decimal SaldosMayores { get; set; }

		/// <summary>
		/// Gets or sets the configuration identifier.
		/// </summary>
		/// <value>
		/// The configuration identifier.
		/// </value>
		[Column("ConfigurationId", TypeName = "uniqueidentifier")]
		public Guid ConfigurationId { get; set; }

		/// <summary>
		/// Gets or sets the task identifier.
		/// </summary>
		/// <value>
		/// The task identifier.
		/// </value>
		[Column("TaskId", TypeName = "uniqueidentifier")]
		public Guid TaskId { get; set; }

		/// <summary>
		/// Gets or sets the client configuration.
		/// </summary>
		/// <value>
		/// The client configuration.
		/// </value>
		[ForeignKey("ConfigurationId")]
		public ClientConfiguration ClientConfiguration { get; set; }

		/// <summary>
		/// Gets or sets the service task.
		/// </summary>
		/// <value>
		/// The service task.
		/// </value>
		[ForeignKey("TaskId")]
		public ServiceTask ServiceTask { get; set; }
	}
}
