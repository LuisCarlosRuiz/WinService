// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the DbSoari Test type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.SoariModelTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using ServiceModel.Entities.ConectionEngine;
	using ServiceModel.Entities.dbService;
	using ServiceModel.Entities.Soari;
	using ServiceModel.Facade;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// The soari DbSoari Test
	/// </summary>
	[TestClass]
	public class DbSoariTest
	{
		/// <summary>
		/// Gets the nits from diferent database test.
		/// </summary>
		[TestMethod]
		public void GetNitsFromDiferentDBTest()
		{
			SoariFacade objFac1 = new SoariFacade("0001");
			SoariFacade objFac2 = new SoariFacade("0002");
			SoariFacade objFac3 = new SoariFacade("0003");

			var lstNit1 = objFac1.GetNit();
			var lstNit2 = objFac2.GetNit();
			var lstNit3 = objFac3.GetNit();

			if (!lstNit1.Any() || !lstNit2.Any() || !lstNit3.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the nit test.
		/// </summary>
		[TestMethod]
		public void GetNitTest()
		{
			List<Nit> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Nit>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.numNit)
							, 1000, 0,
							@"Agencia, Pais
							, Departamento , Ciudad , Genero
							, TipoContrato , NivelEstudio , EstadoCivil
							, Ocupacion , SectorEconomico , JornadaLaboral
							, ActividadEconomica, TipoIdentificacion"
							).ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the nit test.
		/// </summary>
		[TestMethod]
		public void GetCreditoTest()
		{
			List<Credito> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Credito>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.numNit)
							, 1000, 0,
							@"Agencia, TipoGarantia
							, TipoCuota , TipoModalidad"
							).ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}
	}
}
