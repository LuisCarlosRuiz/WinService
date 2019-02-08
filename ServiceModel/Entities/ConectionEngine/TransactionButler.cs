// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the TransactionButler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.ConectionEngine
{
	using Client.Bussines;
	using ServiceModel.BussinesLogic.General;
	using ServiceModel.Entities.dbService;
	using System;
	using System.Linq;

	/// <summary>
	/// the transaction butler 
	/// </summary>
	public class TransactionButler
	{
		private string IdCliente;

		/// <summary>
		/// Initializes a new instance of the <see cref="TransactionButler"/> class.
		/// </summary>
		/// <param name="idCliente">The identifier cliente.</param>
		public TransactionButler(string _IdCliente)
		{
			if (string.IsNullOrEmpty(_IdCliente))
				return;
			IdCliente = _IdCliente;
		}

		public GetData Client()
		{
			ClientConfiguration objConfiguration;

			using (var ctx = new DbServiceContext())
			{
				objConfiguration = ctx.ClientConfiguration.Where(q => q.JobId == IdCliente).FirstOrDefault();
			}

			string ServicePassword = new AesManager().Decrypt(objConfiguration.ServicePassword);

			if (!ValidarConexion(objConfiguration))
				throw new NullReferenceException("50004 - Hacen falta parametros para conectar al servicio");

			return new GetData(objConfiguration.ServiceUrl
								, objConfiguration.ServiceUser
								, ServicePassword);
		}

		private bool ValidarConexion(ClientConfiguration objConfiguration)
		{
			if (objConfiguration != null && objConfiguration.State == "A")
				if (!string.IsNullOrEmpty(objConfiguration.ServiceUrl)
					&& !string.IsNullOrEmpty(objConfiguration.ServiceUser)
					&& !string.IsNullOrEmpty(objConfiguration.ServicePassword))
					return true;
				else
					return false;
			else
				return false;
		}
	}
}
