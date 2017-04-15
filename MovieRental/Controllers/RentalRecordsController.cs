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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var CustomerId = collection["CustomerId"];
            var MovieId = collection["MovieId"];
            var DateCheckedOut = collection["DateCheckedOut"];
            var DueDate = collection["DueDate"];

            var newRentalRecords = new RentalRecords // adding customer
            {
                CustomerId = int.Parse(CustomerId),
                MovieId = int.Parse(MovieId),
                DateCheckedOut = DateTime.Parse(DateCheckedOut),
                DueDate = DateTime.Parse(DueDate),
            };

            var updateRentalRecords = new RentalRecords //update customer
            {
                CustomerId = int.Parse(CustomerId),
                MovieId = int.Parse(MovieId),
                DateCheckedOut = DateTime.Parse(DateCheckedOut),
                DueDate = DateTime.Parse(DueDate),

            };
            new RentalRecordsServices().AddRentalRecords(newRentalRecords);

            // TODO: Put into our database
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Edit(int Id)
        //{
        //    var customer = new CustomerServices().GetCustomer(Id);
        //    return View(customer);
        //}

        //[HttpPost] //edit the customer in the database
        //public ActionResult Edit(int Id, FormCollection collection)
        //{

        //    var Name = collection["Name"];
        //    var Email = collection["Email"];
        //    var PhoneNumber = collection["PhoneNumber"];
        //    var newCustomer = new Customers
        //    {
        //        Id = Id,
        //        Name = Name,
        //        Email = Email,
        //        PhoneNumber = PhoneNumber,
        //    };

        //    try
        //    {
        //        new CustomerServices().UpdateCustomer(newCustomer);
        //        return RedirectToAction("Index");
        //    }

        //    catch
        //    {
        //        return View(newCustomer);
        //    }
        //}

    }
}