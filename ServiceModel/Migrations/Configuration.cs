// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the migrations configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Migrations
{
    using System.Data.Entity.Migrations;
	using ServiceModel.Entities.dbService;

	internal sealed class Configuration : DbMigrationsConfiguration<DbServiceContext>
    {
        public Configuration()
        {
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
		}

        protected override void Seed(ServiceModel.Entities.dbService.DbServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
