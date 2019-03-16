/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the EstadoAhorro type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Estado Ahorro
	//// </summary>
	[Table("tblEstadosAhorros")]
	public class EstadoAhorro
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod estado ahorro.
		/// </summary>
		/// <value>
		/// The string cod estado ahorro.
		/// </value>
		[Key]
		public string strCodEstadoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the string nombre estado ahorro.
		/// </summary>
		/// <value>
		/// The string nombre estado ahorro.
		/// </value>
		public string strNombreEstadoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}