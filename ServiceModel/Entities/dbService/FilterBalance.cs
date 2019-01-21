// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Filtro Balance type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Filtro Balance
	/// </summary>
	[Table("FilterBalance")]
	public class FilterBalance
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("FilterId")]
		public Guid FilterId { get; set; }

		/// <summary>
		/// Gets or sets the configuracion identifier.
		/// </summary>
		/// <value>
		/// The configuracion identifier.
		/// </value>
		[Column("ConfiguracionId", TypeName = "uniqueidentifier")]
		public Guid ConfiguracionId { get; set; }

		/// <summary>
		/// Gets or sets the saldos mayores.
		/// </summary>
		/// <value>
		/// The saldos mayores.
		/// </value>
		[Column("SaldosMayores", TypeName = "decimal")]
		public decimal SaldosMayores { get; set; }

		/// <summary>
		/// Gets or sets the ano.
		/// </summary>
		/// <value>
		/// The ano.
		/// </value>
		[Column("Ano", TypeName = "int")]
		public int Ano { get; set; }

		/// <summary>
		/// Gets or sets the mes.
		/// </summary>
		/// <value>
		/// The mes.
		/// </value>
		[Column("Mes", TypeName = "int")]
		public int Mes { get; set; }

		/// <summary>
		/// Gets or sets the cuenta.
		/// </summary>
		/// <value>
		/// The cuenta.
		/// </value>
		[NotMapped]
		public virtual Cuenta Cuenta { get; set; }

		/// <summary>
		/// Gets or sets the client configuration.
		/// </summary>
		/// <value>
		/// The client configuration.
		/// </value>
		[ForeignKey("ConfiguracionId")]
		public ClientConfiguration clientConfiguration { get; set; }
	}
}
