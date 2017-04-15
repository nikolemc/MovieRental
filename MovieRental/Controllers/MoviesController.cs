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

        public ActionResult IndexCheckedOut()
        {

            // get all movies
            var movies = new MovieRentalServices().CheckedOutMovies();
            // pass them to the view
            // return View("IndexCheckedOut", movies);
            return View("IndexCheckedOut",movies.Where(x => x.IsCheckedOut == true)); //this is my SQL statement for only showing
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
            var GenreId = collection["GenreId"];
            var Director = collection["Director"];
            var YearReleased = collection["YearReleased"];
            var IsCheckedOut = collection["IsCheckedOut"];

            var newMovie = new Movies // adding movie
            {
                Name = Name,
                GenreId = int.Parse(GenreId),
                Director = Director,
                YearReleased = int.Parse(YearReleased),
                IsCheckedOut = bool.Parse(IsCheckedOut),
            };

            var updateMovie = new Movies //update movie
            {
                Name = Name,
                GenreId = int.Parse(GenreId),
                Director = Director,
                YearReleased = int.Parse(YearReleased),
                IsCheckedOut = bool.Parse(IsCheckedOut),

            };
            // make a new movie with these ^^^
            // send that movie to the db with a method/service
            new MovieRentalServices().AddMovie(newMovie);

            // TODO: Put into our database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var movie = new MovieRentalServices().GetMovie(Id);
            return View(movie);
        }

        [HttpPost] //edit the movies in the database
        public ActionResult Edit(int Id, FormCollection collection)
        {

            //Movie movie = GetMovieFromDatabase(Id);
            var Name = collection["Name"];
            var GenreId = collection["GenreId"];
            var YearReleased = collection["YearReleased"];
            var Director = collection["Director"];
            var IsCheckedOut = collection["IsCheckedOut"];
            var newMovie = new Movies // adding Movie
            {
                Id = Id,
                Name = Name,
                GenreId = int.Parse(GenreId),
                YearReleased = int.Parse(YearReleased),
                Director = Director,
                IsCheckedOut = bool.Parse(IsCheckedOut),
            };

            try
            {
                new MovieRentalServices().UpdateMovie(newMovie);
                return RedirectToAction("Index");
            }

            catch
            {
                return View(newMovie);
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var movie = new MovieRentalServices().GetMovie(Id);
            return View(movie);
        }

        [HttpPost] //edit the movies in the database
        public ActionResult Delete(int Id, FormCollection collection)
        {
            var Name = collection["Name"];
            var GenreId = collection["GenreId"];
            var YearReleased = collection["YearReleased"];
            var Director = collection["Director"];
            var IsCheckedOut = collection["IsCheckedOut"];

            new MovieRentalServices().DeleteMovie(Id);
            return RedirectToAction("Index");


        }

    }

}
