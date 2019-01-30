/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the CuotaExtra type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Cuota Extra
	//// </summary>
	[Table("tblContabilidad")]
	public class CuotaExtra
	{
		/// <summary>
		/// Gets or sets the identifier registro.
		/// </summary>
		/// <value>
		/// The identifier registro.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("idRegistro")]
		public int idRegistro { get; set; }

		/// <summary>
		/// Gets or sets the pagare.
		/// </summary>
		/// <value>
		/// The pagare.
		/// </value>
		[Column("strPagare", TypeName = "varchar")]
		[MaxLength(18)]
		public string Pagare { get; set; }

		/// <summary>
		/// Gets or sets the plazo.
		/// </summary>
		/// <value>
		/// The plazo.
		/// </value>
		[Column("numPlazo", TypeName = "int")]
		public int Plazo { get; set; }

		/// <summary>
		/// Gets or sets the valor presente.
		/// </summary>
		/// <value>
		/// The valor presente.
		/// </value>
		[Column("numValorPresente", TypeName = "decimal")]
		public decimal ValorPresente { get; set; }

		/// <summary>
		/// Gets or sets the valor futuro.
		/// </summary>
		/// <value>
		/// The valor futuro.
		/// </value>
		[Column("numValorFuturo", TypeName = "decimal")]
		public decimal ValorFuturo { get; set; }

		/// <summary>
		/// Gets or sets the fecha pago.
		/// </summary>
		/// <value>
		/// The fecha pago.
		/// </value>
		[Column("dteFechaPago", TypeName = "datetime")]
		public DateTime FechaPago { get; set; }

		/// <summary>
		/// Gets or sets the pagada.
		/// </summary>
		/// <value>
		/// The pagada.
		/// </value>
		[Column("strPagada", TypeName = "char")]
		[MaxLength(1)]
		public string Pagada { get; set; }
	}
}
