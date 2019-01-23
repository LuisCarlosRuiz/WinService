// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Nits Dao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic
{
	using ServiceModel.DAO;
	using ServiceModel.Entities.Soari;
	using System.Collections.Generic;

	/// <summary>
	/// the nit logic layer
	/// </summary>
	public class NitBL
	{
		private string ConfigurationId;

		/// <summary>
		/// Initializes a new instance of the <see cref="NitBL"/> class.
		/// </summary>
		/// <param name="_ConfigurationId">The configuration identifier.</param>
		public NitBL(string _ConfigurationId)
		{
			ConfigurationId = _ConfigurationId;
		}

		/// <summary>
		/// Gets the nit list.
		/// </summary>
		/// <returns></returns>
		public List<Nit> GetNit()
		{
			return new NitsDao(ConfigurationId).GetNit();
		}
	}
}
