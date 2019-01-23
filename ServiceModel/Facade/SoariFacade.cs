// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Soari Facade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Facade
{
	using ServiceModel.BussinesLogic;
	using ServiceModel.Entities.Soari;
	using System.Collections.Generic;

	/// <summary>
	/// the soari Facade
	/// </summary>
	public class SoariFacade
	{
		private string ConfigurationId;

		/// <summary>
		/// Initializes a new instance of the <see cref="SoariFacade"/> class.
		/// </summary>
		/// <param name="_ConfigurationId">The configuration identifier.</param>
		public SoariFacade(string _ConfigurationId)
		{
			ConfigurationId = _ConfigurationId;
		}

		/// <summary>
		/// Gets the nit list.
		/// </summary>
		/// <returns></returns>
		public List<Nit> GetNit()
		{
			return new NitBL(ConfigurationId).GetNit();
		}
	}
}
