/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the NovedadVaria type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Novedades Varias
	//// </summary>
	[Table("tblContabilidad")]
	public class NovedadVaria
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
		/// Gets or sets the identificacion.
		/// </summary>
		/// <value>
		/// The identificacion.
		/// </value>
		[Column("numIdentificacion", TypeName = "bigint")]
		public long Identificacion { get; set; }

		/// <summary>
		/// Gets or sets the consecutivo.
		/// </summary>
		/// <value>
		/// The consecutivo.
		/// </value>
		[Column("numConsecutivo", TypeName = "bigint")]
		public long Consecutivo { get; set; }

		/// <summary>
		/// Gets or sets the nombre novedad.
		/// </summary>
		/// <value>
		/// The nombre novedad.
		/// </value>
		[Column("strNombreNovedad", TypeName = "varchar")]
		[MaxLength(150)]
		public string NombreNovedad { get; set; }

		/// <summary>
		/// Gets or sets the saldo inicial.
		/// </summary>
		/// <value>
		/// The saldo inicial.
		/// </value>
		[Column("numSaldoInicial", TypeName = "decimal")]
		public decimal SaldoInicial { get; set; }

		/// <summary>
		/// Gets or sets the saldo final.
		/// </summary>
		/// <value>
		/// The saldo final.
		/// </value>
		[Column("numSaldoFinal", TypeName = "decimal")]
		public decimal SaldoFinal { get; set; }

		/// <summary>
		/// Gets or sets the cuota.
		/// </summary>
		/// <value>
		/// The cuota.
		/// </value>
		[Column("numCuota", TypeName = "decimal")]
		public decimal Cuota { get; set; }
	}
}
