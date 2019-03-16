// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Homologation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.SyncJobs
{
	using ServiceModel.BussinesLogic.General;
	using ServiceModel.Entities.ConectionEngine;
	using ServiceModel.Entities.Partial;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;

	/// <summary>
	/// The Homologation
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	public class Homologation<TEntity> where TEntity : class
	{
		private string idcliente, taskName, clientName;

		/// <summary>
		/// Initializes a new instance of the <see cref="Homologation{TEntity}"/> class.
		/// </summary>
		/// <param name="cliente">The cliente.</param>
		public Homologation(string cliente, string task, string client)
		{
			if (string.IsNullOrEmpty(cliente) || string.IsNullOrEmpty(task) || string.IsNullOrEmpty(client))
				throw new NullReferenceException("Argumento de homologacion nulo.");

			this.idcliente = cliente;
			this.taskName = task;
			this.clientName = client;
		}

		/// <summary>
		/// return the homologation.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="HomologationKeyValue">The homologation key value.</param>
		/// <param name="homologationKeyName">Name of the homologation key.</param>
		/// <param name="valueKeyToReturn">The value key to return.</param>
		/// <returns></returns>
		public object GetHomologation(object HomologationKeyValue, string homologationKeyName, string valueKeyToReturn)
		{
			var entity = TakeDataHomologation();

			int homologationId = 0;
			var entityType = entity.FirstOrDefault().GetType();
			var type = entity.FirstOrDefault().GetType().GetProperty(homologationKeyName);


			if (HomologationKeyValue == null || string.IsNullOrEmpty(HomologationKeyValue.ToString()))
				return 0;

			var data = entity
				.Where(x => x.GetType().GetProperty(homologationKeyName)
				.GetValue(x).ToString() == HomologationKeyValue.ToString())
				.Select(q => q.GetType().GetProperty(valueKeyToReturn)
				.GetValue(q)).FirstOrDefault();

			if (data == null)
			{
				homologationId = SaveNewHomologation(entity, HomologationKeyValue, homologationKeyName, valueKeyToReturn);
			}

			return data ?? homologationId;
		}

		/// <summary>
		/// Saves the new homologation.
		/// </summary>
		/// <param name="dataObject">The data object.</param>
		/// <param name="value">The value.</param>
		/// <param name="FieldName">Name of the field.</param>
		public int SaveNewHomologation(IEnumerable<object> dataObjectList, object value, string FieldName, string returnValue)
		{
			using (var ctx = new Deal(idcliente).DbSoaryContext())
			{
				int Id = 0;
				var dataObject = dataObjectList.FirstOrDefault();
				var objectProperties = dataObjectList.FirstOrDefault().GetType().GetProperties();

				foreach (var item in objectProperties)
				{
					object valuetoInsert;
					
					if (item.Name == FieldName)
						valuetoInsert = value;
					else
					{
						var id = dataObjectList.OrderByDescending(q => q.GetType().GetProperty(returnValue))
							.Select(q => q.GetType().GetProperty(returnValue).GetValue(q)).Max();
						valuetoInsert = (int)(id ?? -1) + 1;
						Id = (int)valuetoInsert;

						if (!item.PropertyType.Name.ToLower().Contains("int"))
							valuetoInsert =  valuetoInsert.ToString();
					}

					dataObject.GetType().GetProperty(item.Name).SetValue(dataObject, valuetoInsert);
				}

				var table = ctx.Set(dataObject.GetType());
				table.Add(dataObject);
				ctx.SaveChanges();

				LogHomologationNull((string)value, dataObject.GetType().Name, FieldName);

				return Id;
			}
		}
		
		/// <summary>
		/// Takes the data homologation.
		/// </summary>
		/// <param name="dataObject">The data object.</param>
		/// <returns></returns>
		private IEnumerable<TEntity> TakeDataHomologation()
		{
			using (var ctx = new Deal(idcliente).DbSoaryContext())
			{
				DbSet<TEntity> dbSet = ctx.Set<TEntity>();
				var data = dbSet.AsQueryable().ToArray();
				return data;
			}
		}

		/// <summary>
		/// Catch the homologacion event and save the log when is null.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="table">The table.</param>
		/// <param name="type">The type.</param>
		internal void LogHomologationNull(string value, string table, string type)
		{
			string Task = $"Homologacion-({taskName})";
			string Log = $@"Se almaceno parcialmente el valor [{value}] en el campo [{type}] de la tabla [{table}], ya que este no existe en la BD.";

			new LogManager().ExecutionLog(clientName, Task, Log, true, MessageEnum.HomologationError);
		}
	}
}
