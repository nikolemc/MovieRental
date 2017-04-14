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

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var genre = new GenreServices().GetGenre(Id);
            return View(genre);
        }

        [HttpPost] //edit the genre in the database
        public ActionResult Edit(int Id, FormCollection collection)
        {

            var Genre = collection["Genre"];
            var newGenre = new Genres
            {
                Id = Id,
                Genre = Genre,
            };

            try
            {
                new GenreServices().UpdateGenre(newGenre);
                return RedirectToAction("Index");
            }

            catch
            {
                return View(newGenre);
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var genre = new GenreServices().GetGenre(Id);
            return View(genre);
        }

        [HttpPost]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            var Genre = collection["Genre"];

            new GenreServices().DeleteGenre(Id);
            return RedirectToAction("Index");


        }

    }


}