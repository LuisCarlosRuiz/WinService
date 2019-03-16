/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Contabilidad type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Contabilidad
	//// </summary>
	[Table("tblContabilidad")]
	public class Contabilidad
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
		/// Gets or sets the identifier agencia.
		/// </summary>
		/// <value>
		/// The identifier agencia.
		/// </value>
		[Column("IdAgencia", TypeName = "int")]
		public int IdAgencia { get; set; }

		/// <summary>
		/// Gets or sets the numero cuenta.
		/// </summary>
		/// <value>
		/// The numero cuenta.
		/// </value>
		[Column("strNumeroCuenta", TypeName = "varchar")]
		[MaxLength(20)]
		public string NumeroCuenta { get; set; }

		/// <summary>
		/// Gets or sets the nombre cuenta.
		/// </summary>
		/// <value>
		/// The nombre cuenta.
		/// </value>
		[Column("strNombreCuenta", TypeName = "varchar")]
		[MaxLength(200)]
		public string NombreCuenta { get; set; }

		/// <summary>
		/// Gets or sets the saldo cuenta.
		/// </summary>
		/// <value>
		/// The saldo cuenta.
		/// </value>
		[Column("numSaldoCuenta", TypeName = "decimal")]
		public decimal SaldoCuenta { get; set; }

		/// <summary>
		/// Gets or sets the fecha saldo.
		/// </summary>
		/// <value>
		/// The fecha saldo.
		/// </value>
		[Column("dteFechaSaldo", TypeName = "datetime")]
		public DateTime FechaSaldo { get; set; }
	}
}
