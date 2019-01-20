using System;


namespace Client
{
	public class SoapiConection
	{

		private string Url, User, Password; 

		public SoapiConection(string _Url, string _User, string _Password)
		{
			Url = _Url;
			User = _User;
			Password = _Password;
		}

		private void SoariConection()
		{
			var obj = new Client.SoapiClient();
		}
	}
}
