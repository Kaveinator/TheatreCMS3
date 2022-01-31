using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Helpers;
using TheatreCMS3.Models;


namespace TheatreCMS3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            //This section below is used for testing the Truncate method. Simply
            //uncomment the below code to test the Truncate method. Make sure
            //to put a breakpoint on this comment to debug by stepping 
            //through each line of code.
/*            string testSentence = "The sunset in that movie was beautiful.";
            string modifiedSentence = testSentence.Truncate(12);
            Console.WriteLine(modifiedSentence); //useful in theory but I have not figured out how to view the console output*/

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignIn()
        {

            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }


    }
}