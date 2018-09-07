using CMS.DataAccsess.Concrate;
using CMS.Domain.Conrate;

namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CMS.DataAccsess.Concrate.CMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            context.Settings.Add(new Settings()
            {
                Id = 1,
                Copyright = "Tüm Haklarý <a href='http://www.ahmeteminsit.com'>Ahmet Emin ÞÝT</a>e Aittir.",
                Description = "Site Description",
                Url = "http://localhost.com",
            });

            context.Authorizations.AddOrUpdate(new Authorization()
            {
                Id = 1,
                Authority = "SuperAdmin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }, new Authorization()
            {
                Id = 2,
                Authority = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsDeleted = false,
            }, new Authorization()
            {
                Id = 3,
                Authority = "User",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsDeleted = false,
            });

            context.Userses.Add(new Users()
            {
                FirstName = "Ahmet Emin",
                LastName = "ÞÝT",
                AuthorityId = 1,
                Email = "sitahmetemin@gmail.com",
                Password = "123654",
                DisplayName = "sitahmetemin",
                Image = "https://i1.wp.com/www.winhelponline.com/blog/wp-content/uploads/2017/12/user.png?fit=256%2C256&quality=100&ssl=1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}