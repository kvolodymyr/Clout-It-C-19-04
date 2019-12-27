namespace WebApplicationDbcontext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplicationDbcontext.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplicationDbcontext.Models.CarPoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplicationDbcontext.Models.CarPoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Vehicles.AddOrUpdate(new Vehicle
            {
                Name = "Toyota"
            }, new Vehicle
            {
                Name = "Jeep"
            }, new Vehicle
            {
                Name = "Zaz"
            });
            context.SaveChanges();

            context.Drivers.AddOrUpdate(new Driver
            {
                Name = "Vasya"
            }, new Driver
            {
                Name = "Bob"
            }, new Driver
            {
                Name = "Tanya"
            });
            context.SaveChanges();
        }
    }
}
