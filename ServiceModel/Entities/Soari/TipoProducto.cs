/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoProducto type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Tipo Producto
	//// </summary>
	[Table("tblTiposProducto")]
	public class TipoProducto
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod tipo producto.
		/// </summary>
		/// <value>
		/// The string cod tipo producto.
		/// </value>
		[Key]
		public string strCodTipoProducto { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo producto.
		/// </summary>
		/// <value>
		/// The string nombre tipo producto.
		/// </value>
		public string strNombreTipoProducto { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}