using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class SurveyAnalyst: ApplicationUser
    {
        public int CallBackSurveys { get; set; }

        public int SurveyTimeWindow { get; set; }

    
        //creates method to seed data
        public static void SurveyAnalystSeed(TheatreCMS3.Models.ApplicationDbContext context)
        {
            //instantiates database object
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //if info added isn't in the database
            if (userManager.FindByNameAsync("surveyAnalyst").Result == null)
            {
                //add this data
                var surveyAnalyst = new SurveyAnalyst
                {
                    
                    UserName = "SurveyAnalyst25",
                    Email = "SurveyAnalyst25@gmail.com",
                    CallBackSurveys = 10,
                    SurveyTimeWindow = 25

                };


                IdentityResult result = userManager.CreateAsync(surveyAnalyst, "Surveys").Result;
                //creates user role and assigns it to the SurveyAnalyst being seeded.
                userManager.Create(surveyAnalyst);
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(surveyAnalyst.Id, "surveyAnalyst").Wait();
                };
            }

        }
    }
}