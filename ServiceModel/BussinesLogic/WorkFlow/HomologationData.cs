// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the HomologationData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ServiceModel.BussinesLogic.WorkFlow
{
	using System.Collections;
	using System;
	using ServiceModel.Entities.Soari;
	using ServiceModel.Entities.ConectionEngine;
	using System.Linq;
	using System.Collections.Generic;

	/// <summary>
	/// the homologation data 
	/// </summary>
	internal class HomologationData
	{
		private string idClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="HomologationData"/> class.
		/// </summary>
		/// <param name="idClient">The identifier client.</param>
		public HomologationData(string idClient)
		{
			this.idClient = idClient;
		}

		/// <summary>
		/// Gets the homologation agencia.
		/// </summary>
		/// <param name="strEquivalenciaOPA">The string equivalencia opa.</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException">50001  - Falta un parametro de consulta</exception>
		public List<Agencia> GetHomologationAgencia()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50000  - Falta un parametro para la consulta de agencia");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.Agencia.ToList();
			}
		}

		/// <summary>
		/// Gets the homologation agencia.
		/// </summary>
		/// <param name="strEquivalenciaOPA">The string equivalencia opa.</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException">50001  - Falta un parametro de consulta</exception>
		public List<Ciudad> GetHomologationCiudad()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta de ciudad");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.Ciudad.ToList();
			}
		}

	}
}
