// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Cuenta type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Cuenta
	/// </summary>
	[Table("Cuenta")]
	public class Cuenta
	{
		/// <summary>
		/// Gets or sets the cuenta identifier.
		/// </summary>
		/// <value>
		/// The cuenta identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CuentaId")]
		public Guid CuentaId { get; set; }

		/// <summary>
		/// Gets or sets the codigo cuenta.
		/// </summary>
		/// <value>
		/// The codigo cuenta.
		/// </value>
		[Column("CodigoCuenta", TypeName = "varchar")]
		[MaxLength(10)]
		public string CodigoCuenta { get; set; }

		/// <summary>
		/// Gets or sets the nombre cuenta.
		/// </summary>
		/// <value>
		/// The nombre cuenta.
		/// </value>
		[Column("NombreCuenta", TypeName = "varchar")]
		[MaxLength(200)]
		public string NombreCuenta { get; set; }

		/// <summary>
		/// Gets or sets the filtro identifier.
		/// </summary>
		/// <value>
		/// The filtro identifier.
		/// </value>
		[Column("FiltroId", TypeName = "uniqueidentifier")]
		public Guid FiltroId { get; set; }

		/// <summary>
		/// Gets or sets the filter balance.
		/// </summary>
		/// <value>
		/// The filter balance.
		/// </value>
		[ForeignKey("FiltroId")]
		public FilterBalance FilterBalance { get; set; }
	}
}
