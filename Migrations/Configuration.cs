namespace Jarvis.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Jarvis.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Jarvis.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Jarvis.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.DeviceStatus.AddOrUpdate(
                new DeviceStatus { Identification = "DEV001", Status = 1, Created = 1431825150 },
                new DeviceStatus { Identification = "DEV002", Status = 1, Created = 1431825150 }
            );
        }
    }
}
