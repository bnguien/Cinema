using MyMVCApp.Models;
using MyMVCApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MyMVCApp.ViewModels;
namespace MyMVCApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }


        public IActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            return View(movie);
        }
        public IActionResult New()
        {
            var movie = new MovieFormViewModel()
            {
                Movie = new Movie()
            };
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel { Movie = movie };
                return View("New", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                if (movieInDb == null) return NotFound();

                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var viewModel = new MovieFormViewModel { Movie = movie };
            return View("New", viewModel);
        }
    }
}