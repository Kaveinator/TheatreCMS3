using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class HeadAuthor : ApplicationUser
    {
        public int ViewsPerMonth { get; set; }
        public int AuthorsHired { get; set; }
        public int AuthorsLetGo { get; set; }
    }
    public class Seedata
    {

        public static void HeadAuthorSeed(IServiceProvider serviceProvider)
        {

            Console.WriteLine("Seeding the HeadAuthor...");
            var userManager = new UserManager<HeadAuthor>(new UserStore<HeadAuthor>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            // Ensure the "HeadAuthor" role exists
            if (!roleManager.RoleExists("HeadAuthor"))
            {
                var role = new IdentityRole { Name = "HeadAuthor" };
                var roleResult = roleManager.Create(role);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Failed to create the 'HeadAuthor' role.");
                    return;
                }
            }

            // Create and seed a HeadAuthor user
            var headAuthor = new HeadAuthor
            {
                UserName = "HeadAuthorUsername",
                ViewsPerMonth = 1000,
                AuthorsHired = 5,
                AuthorsLetGo = 1,
            };

            var userResult = userManager.Create(headAuthor, "YourPassword");
            if (userResult.Succeeded)
            {
                userManager.AddToRole(headAuthor.Id, "HeadAuthor");
            }
            else
            {
                throw new Exception("Failed to create the HeadAuthor user.");
            }
        }
    }
}
