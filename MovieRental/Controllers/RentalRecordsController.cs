using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.Services;


namespace MovieRental.Controllers
{
    public class RentalRecordsController : Controller
    {

        // GET: Genre
        public ActionResult Index()
        {
            // get all genres
            var rentalrecords = new RentalRecordsServices().GetAllRentalRecords();
            // pass them to the view
            return View("Index", rentalrecords);
        }


        // GET: RentalLogs
        public ActionResult IndexContact()
        {
            // get all rental Records
            var rentalrecords = new RentalRecordsServices().GetAllRentalRecordsWithContacts();
            // pass them to the view
            return View("IndexContact", rentalrecords);
        }
    }
}