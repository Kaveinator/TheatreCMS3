using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhotographer : ApplicationUser
    {
        public string Camera { get; set; }
        public double CameraCost { get; set; }
        public string CameraSerialNumber { get; set; }

        public static void Seed(ApplicationDbContext dbContext)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));

            //checking if role exists
            if (!roleManager.RoleExists("ProductionManager"))
            {
               var roleResult = roleManager.Create(new IdentityRole("ProductionManager"));                   
                
            }
        
            
            var prodManager =  new ProductionPhotographer()
            {
                UserName = "ProductionManager",
                Email = "manage@production.com",
                PhoneNumber = "3475555555",
            };

            string password = "P@ssw0rd4!";

            //passing ProductionPhotographer object to user manager to create the user
            var userResult = UserManager.Create(prodManager, password);
            if (userResult.Succeeded) //if user successfully created
            {   
                //add user to productionmanager role
                UserManager.AddToRole(prodManager.Id, "ProductionManager");
            }
            


        }
    }
}