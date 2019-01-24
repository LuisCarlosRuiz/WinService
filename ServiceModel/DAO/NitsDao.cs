// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Nits Dao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.DAO
{
	using ServiceModel.Entities.ConectionEngine;
	using ServiceModel.Entities.Soari;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// the Nits data access
	/// </summary>
	internal class NitsDao
	{
		private string ConfigurationId;

		/// <summary>
		/// Initializes a new instance of the <see cref="NitsDao"/> class.
		/// </summary>
		/// <param name="_ConfigurationId">The configuration identifier.</param>
		public NitsDao(string _ConfigurationId)
		{
			ConfigurationId = _ConfigurationId;
		}

		/// <summary>
		/// Gets the nit list.
		/// </summary>
		/// <returns></returns>
		public List<Nit> GetNit()
		{
			using (var ctx = new Deal(ConfigurationId).DbSoaryContext())
			{
				return ctx.Nit.ToList();
			}
		}
	}
}
