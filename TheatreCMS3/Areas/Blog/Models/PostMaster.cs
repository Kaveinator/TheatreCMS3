using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class PostMaster : ApplicationUser
    {
        public int PublishedBlogPosts { get; set; } //the total number of BlogPosts that this PostMaster has published to the public
        public int RejectedBlogPosts { get; set; } //the number of BlogPosts taht a BlogAuthor wrote that this PostMaster has rejected
        public int PendingBlogPosts { get; set; } //the number of BlogPosts that are waiting for the PostMaster to review


        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                //creating an instance of PostMaster
                var postMaster = new PostMaster { UserName = "egarcia", Email = "blogadmin@gmail.com", PasswordHash = "12345", PublishedBlogPosts = 4, RejectedBlogPosts = 2, PendingBlogPosts = 1 };
                //using ApplicationDbContext to later add PostMaster instant to database
                context.PostMasters.Add(postMaster);
                //creating an instance of UserStore -- object from Identity framework that allows to work with an application user
                var userStore = new UserStore<PostMaster>(context); //pass context to it to tell userStore what delivers item to the database
                userStore.CreateAsync(postMaster);//posting to database
                //need object back from database, find by email address, to get all of the properties back
                var userResult = userStore.FindByEmailAsync(postMaster.Email).Result; //.Result forces a wait to happen for information from database                              
                //sending back to database to add to UserRoles
                var userRoleResult = userStore.AddToRoleAsync(userResult, "PostMaster");
                userRoleResult.Wait();//forces a wait for information from database

                //saves information to database
                context.SaveChanges();
            }
     
        }
    }
}
