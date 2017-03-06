namespace BlogV3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogV3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogV3.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(
             new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "Aliciamaccara@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Aliciamaccara@gmail.com",
                    Email = "Aliciamaccara@gmail.com",
                    FirstName = "Alicia",
                    LastName = "MacCara",
                    DisplayName = "Alimariemac"
                }, "Testpassword123!");
            }

            if (!context.Users.Any(u => u.Email == "moderator@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "moderator@coderfoundry.com",
                    Email = "moderator@coderfoundry.com",
                    FirstName = "Moderator",
                    LastName = "CF",
                    DisplayName = "Moderator"
                }, "Password-1");
            }

            var userId = userManager.FindByEmail("Aliciamaccara@gmail.com").Id;
            var moderator = userManager.FindByEmail("moderator@coderfoundry.com").Id;

            userManager.AddToRole(userId, "Admin");
            userManager.AddToRole(moderator, "Moderator");
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
        }
    }
}
