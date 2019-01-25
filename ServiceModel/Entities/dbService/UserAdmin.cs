// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the UserAdmin type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// The user admin 
	/// </summary>
	[Table("UserAdmin")]
	internal class UserAdmin
	{
		/// <summary>
		/// Gets or sets the mail identifier.
		/// </summary>
		/// <value>
		/// The mail identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("UserId")]
		public Guid UserId { get; set; }

		/// <summary>
		/// Gets or sets the user code.
		/// </summary>
		/// <value>
		/// The user code.
		/// </value>
		[Column("UserCode", TypeName = "char")]
		[MaxLength(4)]
		public string UserCode { get; set; }

		/// <summary>
		/// Gets or sets the nombre integrado.
		/// </summary>
		/// <value>
		/// The nombre integrado.
		/// </value>
		[Column("Name", TypeName = "varchar")]
		[MaxLength(200)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the mail.
		/// </summary>
		/// <value>
		/// The mail.
		/// </value>
		[Column("Mail", TypeName = "varchar")]
		[MaxLength(200)]
		public string Mail { get; set; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		[Column("State", TypeName = "char")]
		[MaxLength(1)]
		public string State { get; set; }
	}
}
