using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class PostMaster : ApplicationUser
    {
        public int PublishedBlogPosts { get; set; }
        public int RejectedBlogPosts { get; set; }
        public int PendingBlogPosts { get; set; }

        public static void Seed() 
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("PostMaster"))
            {
                var role = new IdentityRole
                {
                    Name = "PostMaster"
                };
                roleManager.Create(role);

                PostMaster PostMasterSeed = new PostMaster
                {
                    UserName = "PostMaster",
                    Email = "PostMaster1337@thtrvrt.com",
                    PublishedBlogPosts = 0,
                    RejectedBlogPosts = 0,
                    PendingBlogPosts = 0
                };
                string PostMasterSeedPass = "Password12!";
                var checkPMCreate = userManager.Create(PostMasterSeed, PostMasterSeedPass);

                if(checkPMCreate.Succeeded) 
                { 
                    userManager.AddToRole(PostMasterSeed.Id, "PostMaster"); 
                }
                
                db.Users.Add(PostMasterSeed);
                db.SaveChanges();
            }
        }


        

        
        

    }
}