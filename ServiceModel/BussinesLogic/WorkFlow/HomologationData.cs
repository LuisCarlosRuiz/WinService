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
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

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
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.Ciudad.ToList();
			}
		}

		internal List<TipoGarantia> GetHomologationTipoGarantia()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.TipoGarantia.ToList();
			}
		}

		internal List<TipoModalidad> GetHomologationModalidad()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.TipoModalidad.ToList();
			}
		}

		/// <summary>
		/// Gets the homologation tipo contrato.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NullReferenceException">50010  - Falta un parametro para la consulta</exception>
		internal List<TipoContrato> GetHomologationTipoContrato()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.TipoContrato.ToList();
			}
		}

		/// <summary>
		/// Gets the homologation tipo identificacion.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NullReferenceException">50001  - Falta un parametro para la consulta</exception>
		internal List<TipoIdentificacion> GetHomologationTipoIdentificacion()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.TipoIdentificacion.ToList();
			}
		}

		/// <summary>
		/// Gets the homologation genero.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NullReferenceException">50012  - Falta un parametro para la consulta</exception>
		internal List<Genero> GetHomologationGenero()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.Genero.ToList();
			}
		}

		/// <summary>
		/// Gets the homologation departamento.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NullReferenceException">50011  - Falta un parametro para la consulta</exception>
		internal List<Departamento> GetHomologationDepartamento()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.Departamento.ToList();
			}
		}

		/// <summary>
		/// Gets the homologation pais.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NullReferenceException">50001  - Falta un parametro para la consulta</exception>
		internal List<Pais> GetHomologationPais()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.Pais.ToList();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TipoCuota">The type of the ipo cuota.</typeparam>
		internal List<TipoCuota> GetHomologationTipoCuota()
		{
			if (string.IsNullOrEmpty(idClient))
				throw new NullReferenceException("50001  - Falta un parametro para la consulta");

			using (var ctx = new Deal(idClient).DbSoaryContext())
			{
				return ctx.TipoCuota.ToList();
			}
		}
	}
}
