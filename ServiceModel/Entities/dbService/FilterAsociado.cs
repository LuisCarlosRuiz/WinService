// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Filter Asociado type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Filter Asociado
	/// </summary>
	[Table("FilterAsociado")]
	public class FilterAsociado
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		[Column("")]
		public int Id { get; set; }
	}
}
