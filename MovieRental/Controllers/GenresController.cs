using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.Services;

namespace MovieRental.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            // get all genres
            var genres = new GenreServices().GetAllGenres();
            // pass them to the view
            return View("Index", genres);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var Genre = collection["Genre"];

            var newGenre = new Genres 
            {
                Genre = Genre,
            };

            var updateCustomer = new Genres 
            {
                Genre = Genre,

            };
            new GenreServices().AddGenre(newGenre);

            // TODO: Put into our database
            return RedirectToAction("Index");
        }

    }


}