// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Soary Context type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ServiceModel.Entities.Soari
{
	internal class SoaryContext : DbContext
	{

		public SoaryContext(string connString) : base(connString)
		{
			var adapter = (IObjectContextAdapter)this;
			var objectContext = adapter.ObjectContext;
			objectContext.CommandTimeout = int.MaxValue;
		}

		/// <summary>
		/// Gets or sets the nit.
		/// </summary>
		/// <value>
		/// The nit.
		/// </value>
		public DbSet<Nit> Nit { get; set; }		
	}
}
