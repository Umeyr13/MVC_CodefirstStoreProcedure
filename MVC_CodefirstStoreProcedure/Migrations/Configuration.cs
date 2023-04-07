namespace MVC_CodefirstStoreProcedure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_CodefirstStoreProcedure.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//false du true yaptık;
            ContextKey = "MVC_CodefirstStoreProcedure.Models.DatabaseContext";
        }

        protected override void Seed(MVC_CodefirstStoreProcedure.Models.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
