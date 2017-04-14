using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.Services;

namespace MovieRental.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            // get all customers
            var customers = new CustomerServices().GetAllCustomers();
            // pass them to the view
            return View("Index", customers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var Name = collection["Name"];
            var Email = collection["Email"];
            var PhoneNumber = collection["PhoneNumber"];

            var newCustomer = new Customers // adding customer
            {
                Name = Name,
                Email = Email,
                PhoneNumber = PhoneNumber,
            };

            var updateCustomer = new Customers //update customer
            {
                Name = Name,
                Email = Email,
                PhoneNumber = PhoneNumber,

            };
            new CustomerServices().AddCustomer(newCustomer);

            // TODO: Put into our database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var customer = new CustomerServices().GetCustomer(Id);
            return View(customer);
        }

        [HttpPost] //edit the customer in the database
        public ActionResult Edit(int Id, FormCollection collection)
        {
            
            var Name = collection["Name"];
            var Email = collection["Email"];
            var PhoneNumber = collection["PhoneNumber"];
            var newCustomer = new Customers 
            {
                Id = Id,
                Name = Name,
                Email = Email,
                PhoneNumber = PhoneNumber,
            };
            
            try
            {
                new CustomerServices().UpdateCustomer(newCustomer);
                return RedirectToAction("Index");
            }

            catch
            {
                return View(newCustomer);
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var customer = new CustomerServices().GetCustomer(Id);
            return View(customer);
        }

        [HttpPost] 
        public ActionResult Delete(int Id, FormCollection collection)
        {
            var Name = collection["Name"];
            var GenreId = collection["Email"];
            var YearReleased = collection["PhoneNumber"];

            new CustomerServices().DeleteCustomer(Id);
            return RedirectToAction("Index");


        }
    }


}