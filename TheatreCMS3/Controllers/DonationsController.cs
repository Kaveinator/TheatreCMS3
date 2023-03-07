using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Models;

namespace TheatreCMS3.Controllers
{
    public class DonationsController : Controller
    {
        [HttpGet]
        public ActionResult Donate()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Donate(Donation donation)
        {
            if (ModelState.IsValid)
            {
                // TODO: Process the donation and redirect to a thank-you page
                return RedirectToAction("ThankYou");
            }

            return View(donation);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}