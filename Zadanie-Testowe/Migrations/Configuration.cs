namespace Zadanie_Testowe.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Zadanie_Testowe.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Zadanie_Testowe.Models.DbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Zadanie_Testowe.Models.DbModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.TreeElements.AddOrUpdate(x => x.Guid,
                new TreeElement()
                {
                    Guid = Guid.Parse("dc672e46-70bd-4c8d-a9ed-605841531eb3"),
                    Value = "Poland",
                    ParentId = null
                },
                new TreeElement()
                {
                    Guid = Guid.Parse("f55266dd-84c9-4441-8a29-3e8bae49e9fc"),
                    Value = "Miasta",
                    ParentId = Guid.Parse("dc672e46-70bd-4c8d-a9ed-605841531eb3")
                },
                new TreeElement()
                {
                    Guid = Guid.Parse("5a536513-4034-4536-9c5a-52467662cd63"),
                    Value = "Rzeszow",
                    ParentId = Guid.Parse("f55266dd-84c9-4441-8a29-3e8bae49e9fc")
                },
                new TreeElement()
                {
                    Guid = Guid.Parse("ef0380bb-ff68-48d5-9d33-4c7c5e850e11"),
                    Value = "Warszawa",
                    ParentId = Guid.Parse("f55266dd-84c9-4441-8a29-3e8bae49e9fc")
                });

            context.Users.AddOrUpdate(x => x.Username,
                new User()
                {
                    Email = "test@.mail.com",
                    Username = "tests",
                    Password = "MySercretPw"
                });
        }
    }
}