namespace DHL.Receipting.Core.Security.Migrations
{
    using DHL.Receipting.Core.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SecurityConfiguration : DbMigrationsConfiguration<DHL.Receipting.Core.Models.SecurityContext>
    {
        public SecurityConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SecurityContext, SecurityConfiguration>(true, new SecurityConfiguration()));
        }

        protected override void Seed(DHL.Receipting.Core.Models.SecurityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
