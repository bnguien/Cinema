using MyMVCApp.Models;
using MyMVCApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MyMVCApp.ViewModels;
namespace MyMVCApp.Controllers
{
    [Route("movies")]
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
        [HttpGet("")]
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie==null)
            {
                return NotFound("Movie not found");
            }
            return View(movie);
        }
    }
}