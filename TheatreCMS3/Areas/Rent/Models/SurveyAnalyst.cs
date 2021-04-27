using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class SurveyAnalyst : ApplicationUser
    {
        public int CallBackSurveys { get; set; }

        public int SurveyTimeWindow { get; set; }


        //creates method to seed data

        public static void SurveyAnalystSeed(ApplicationDbContext context)
        {


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //check if role exists
            if (!roleManager.RoleExists("SurveyAnalyst"))
            {

                var role = new IdentityRole();
                //creates identity role name
                role.Name = "SurveyAnalyst";
                //creates role manager
                roleManager.Create(role);


                //creates new survey analyst user
                var surveyAnalyst = new SurveyAnalyst
                {

                    UserName = "surveyAnalyst",
                    Email = "surveyAnalyst25@rentalsurveys.com",
                    CallBackSurveys = 10,
                    SurveyTimeWindow = 25

                };



                //creates passwored
                string SurveyUserPassword = "surveyAnalyst55";

                //creates user role
                var checkanalyst = userManager.Create(surveyAnalyst, SurveyUserPassword);

                //checks if creating the user role succeeded
                if (!checkanalyst.Succeeded)
                {
                    //if it does add user to role.
                    userManager.AddToRole(surveyAnalyst.Id, "SurveyAnalyst");
                }

            }

        }
    }
}