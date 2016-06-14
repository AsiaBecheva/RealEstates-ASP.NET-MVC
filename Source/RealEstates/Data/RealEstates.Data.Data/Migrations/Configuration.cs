namespace RealEstates.Data.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using TicketingSystem.Common;
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private UserManager<User> userManager;
        private IRandomGenerator random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedProperties(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Email = string.Format("{0}@{1}.com", this.random.RandomString(6, 16), this.random.RandomString(6, 16)),
                    UserName = this.random.RandomString(6, 16)
                };

                this.userManager.Create(user, "123456");
            }

            var adminUser = new User
            {
                Email = "admin@mysite.com",
                UserName = "Administrator"
            };

            this.userManager.Create(adminUser, "admin123456");

            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
        }

        private void SeedProperties(ApplicationDbContext context)
        {
            if (context.Properties.Any())
            {
                return;
            }

            //var image = this.GetSampleImage();
            var users = context.Users.Take(10).ToList();
            for (int i = 0; i < 20; i++)
            {
                var property = new Property
                {
                    Title = this.random.RandomString(5, 20),
                    Description = this.random.RandomString(200, 500),
                    //Image = image,
                    Author = users[this.random.RandomNumber(0, users.Count - 1)],
                    Sity = RandomEnumValue<Sity>(),
                    Price = this.random.RandomNumber(400, 40000),
                    PropertyStatus = RandomEnumValue<PropertyStatus>(),
                    PropertyType = RandomEnumValue<PropertyType>()
                };
                
                context.Properties.Add(property);
                context.SaveChanges();
            }
        }

        //private Image GetSampleImage()
        //{
        //    var directory = AssemblyHelpers.GetDirectoryForAssembyl(Assembly.GetExecutingAssembly());
        //    var file = File.ReadAllBytes(directory + "/Migrations/Images/property.jpg");
        //    var image = new Image
        //    {
        //        Content = file,
        //        FileExtension = "jpg"
        //    };
        //
        //    return image;
        //}

        private static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}
