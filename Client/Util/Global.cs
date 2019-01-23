using Client;
using Client.SoapiClient;
using System;
using System.Reflection;

namespace Client.Util
{
	public class Global
	{
		public Global()
		{
			
		}

		public MethodInfo[] GetServiceAtributes()
		{
			Type types = (typeof(SOARIFacadeClient));
			MethodInfo[] methods = types.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

			return methods;
		}
	}
}
