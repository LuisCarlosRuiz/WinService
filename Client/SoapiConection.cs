using System.ServiceModel;
using Client.SoapiClient;

namespace Client
{
	public class SoapiConection
	{
		/// <summary>
		/// Global
		/// </summary>
		protected string Url, User, Password; 
		
		/// <summary>
		/// Conect to Soapi service
		/// </summary>
		/// <returns></returns>
		protected SOARIFacadeClient Client()
		{
			SOARIFacadeClient client = new SOARIFacadeClient();

			client.Endpoint.Address = new EndpointAddress(Url);
			client.ClientCredentials.UserName.UserName = User;
			client.ClientCredentials.UserName.Password = Password;

			return client;
		}
	}
}
