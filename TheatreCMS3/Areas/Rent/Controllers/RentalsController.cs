using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Areas.Rent.ViewModels;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/Rentals
        public ViewResult Index(string greaterLessThan, string searchCost)
        {
            //Use keyword "var" to signal ambiguity of rental type
            //Technically it's List<Rental>. 
            var rentals = db.Rentals.ToList();
            IList<AllRentals> allRentals = new List<AllRentals>(); //list of type view model

            //add all items in rentals to view model list
            foreach (var rentItem in rentals)
            {
                AllRentals allRental = new AllRentals(rentItem);               
                allRentals.Add(allRental);
            }

            //Change to ienumerable so the structure is less mutable
            IEnumerable<AllRentals> iAllRentals = allRentals;

            ViewBag.LessThanGreaterThan = "less"; //default value
            if (!String.IsNullOrEmpty(searchCost))
            {
                try
                {
                    decimal cost = Convert.ToDecimal(searchCost);
                    if (greaterLessThan == "less")
                    {
                        iAllRentals = allRentals.Where(s => s.RentalCost < cost);
                    }
                    else
                    {
                        iAllRentals = allRentals.Where(s => s.RentalCost > cost);
                        ViewBag.LessThanGreaterThan = "greater";
                    }
                }
                catch (FormatException) //if letters are inputted
                {
                    ViewBag.searchCostException = "Please enter numbers only";
                }
                catch (Exception) //catches any other exception
                {
                    ViewBag.searchCostException = "Something went wrong. Please try again or contact site administrator.";
                }


            }
            return View(iAllRentals);
        }

        // GET: Rent/Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Use keyword "var" because it's ambiguous which rental type will come out.
            // Type is technically parent type "Rental" but will polymorph to child types.
            var rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }

            //pass rental through viewmodel constructor
            AllRentals allRentals = new AllRentals(rental);

            //get associated rentalRequest

            populateAssociatedRentalRequest(allRentals);
            return View(allRentals);
        }

        //gets associated rental request and puts it in viewbag
        private void populateAssociatedRentalRequest(AllRentals rental)
        {
            RentalRequest rentalRequest = db.RentalRequest.Find(rental.RentalRequestID);
            ViewBag.associatedRentalRequest = rentalRequest;
        }
        // GET: Rent/Rentals/Create
        [RentalManagerAuthorize] //Checks that user has Rental Manager Role
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages," +
            "ChokingHazard,SuffocationHazard,PurchasePrice," +
            "RoomNumber,SquareFootage,MaxOccupancy")] AllRentals allrentals, string name /*comes from last input on view*/)
        {
            bool success = false;

            if (name == "rental")
            {
                success = CreateRental(allrentals);
            }
            else if (name == "equipment")
            {
                success = CreateEquipmentRental(allrentals);
            }
            else if (name == "room")
            {
                success = CreateRoomRental(allrentals);
            }
            if (success)
            {
                return RedirectToAction("Index");
            }
            ViewBag.rentalType = name; //return this name in case an error occurs, it shows the right form.
            return View(allrentals);
        }

        private bool CreateRental(AllRentals allrentals)
        {
            //map the view model to model
            Rental rental = new Rental()
            {
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages
            };

            //validate only model fields
            if (ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages"))
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CreateEquipmentRental(AllRentals allrentals)
        {
            //map the view model to model
            RentalEquipment equipment = new RentalEquipment()
            {
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages,
                ChokingHazard = allrentals.ChokingHazard,
                SuffocationHazard = allrentals.SuffocationHazard,
                PurchasePrice = allrentals.PurchasePrice
            };
            //validate only model fields
            if (ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages") && ModelState.IsValidField("ChokingHazard") &&
                ModelState.IsValidField("SuffocationHazard") && ModelState.IsValidField("PurchasePrice"))
            {
                db.Rentals.Add(equipment);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CreateRoomRental(AllRentals allrentals)
        {
            //map the view model to model
            RentalRoom room = new RentalRoom()
            {
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages,
                RoomNumber = allrentals.RoomNumber,
                SquareFootage = allrentals.SquareFootage,
                MaxOccupancy = allrentals.MaxOccupancy
            };

            //validate only model fields
            if (ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages") && ModelState.IsValidField("RoomNumber") &&
                ModelState.IsValidField("SquareFootage") && ModelState.IsValidField("MaxOccupancy"))
            {
                db.Rentals.Add(room);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        // GET: Rent/Rentals/Edit/5
        [RentalManagerAuthorize] //checks user for rental manager role
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Use keyword "var" because it's ambiguous which rental type will come out.
            //Technically type is of parent "Rental" but will polymorph based on what comes out of db
            var rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }

            //pass rental through view model constructor
            AllRentals allRentals = new AllRentals(rental);

            //setting form on the view
            if (rental.GetType().ToString().Contains("Equipment"))
            {
                ViewBag.rentalType = "equipment";
            }
            else if (rental.GetType().ToString().Contains("Room"))
            {
                ViewBag.rentalType = "room";
            }
            else
            {
                ViewBag.rentalType = "rental";
            }
            
            return View(allRentals);
        }

        // POST: Rent/Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages," +
            "ChokingHazard,SuffocationHazard,PurchasePrice," +
            "RoomNumber,SquareFootage,MaxOccupancy")] AllRentals allrentals, string name)
        {
            bool success = false;

            if (name == "rental")
            {
                success = EditRental(allrentals);
            }
            else if (name == "equipment")
            {
                success = EditEquipmentRental(allrentals);
            }
            else if (name == "room")
            {
                success = EditRoomRental(allrentals);
            }
            if (success)
            {
                return RedirectToAction("Index");
            }

            //Return form type in case error occurs
            ViewBag.RentalType = name;
            return View(allrentals);
        }

        private bool EditRental(AllRentals allrentals)
        {
            //map the view model to model
            Rental rental = new Rental()
            {
                RentalId = allrentals.RentalId,
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages
            };
            //Validate model fields only
            if (ModelState.IsValidField("RentalId") && ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages"))
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool EditEquipmentRental(AllRentals allrentals)
        {
            //map the view model to model
            RentalEquipment equipment = new RentalEquipment()
            {
                RentalId = allrentals.RentalId,
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages,
                ChokingHazard = allrentals.ChokingHazard,
                SuffocationHazard = allrentals.SuffocationHazard,
                PurchasePrice = allrentals.PurchasePrice
            };
            //validate model fields only
            if (ModelState.IsValidField("RentalId") && ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages") && ModelState.IsValidField("ChokingHazard") &&
                ModelState.IsValidField("SuffocationHazard") && ModelState.IsValidField("PurchasePrice"))
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool EditRoomRental(AllRentals allrentals)
        {
            //map the view model to model
            RentalRoom room = new RentalRoom()
            {
                RentalId = allrentals.RentalId,
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages,
                RoomNumber = allrentals.RoomNumber,
                SquareFootage = allrentals.SquareFootage,
                MaxOccupancy = allrentals.MaxOccupancy
            };
            //validate model fields only
            if (ModelState.IsValidField("RentalId") && ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages") && ModelState.IsValidField("RoomNumber") &&
                ModelState.IsValidField("SquareFootage") && ModelState.IsValidField("MaxOccupancy"))
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        // GET: Rent/Rentals/Delete/5
        [RentalManagerAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Use keyword "var" because it's ambiguous which rental type will come out.
            // Technically type is of parent "Rental" but will polymorph to child types based on type from db
            var rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }

            //pass through view model constructor
            AllRentals allRentals = new AllRentals(rental);

            //get associated rental request
            populateAssociatedRentalRequest(allRentals);
            return View(allRentals);
        }

        // POST: Rent/Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // method for rendering the access denied page
        public ActionResult AccessDenied()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
