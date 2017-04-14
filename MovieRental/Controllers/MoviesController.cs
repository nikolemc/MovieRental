using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.Services;


namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        // GET: MovieRental
        public ActionResult Index()
        {
            // get all movies
            var movies = new MovieRentalServices().GetAllMovieWithGenre();
            // pass them to the view
            return View("Index", movies);

        }

    }
}