using MyMVCApp.Models;
using MyMVCApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    private ApplicationDbContext _context;

   public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

    // GET: api/Movies
    [HttpGet]
    public ActionResult<List<Movie>> GetAll()
    {
        return _context.Movies.ToList();
    }

    // GET: api/Movies/5
    [HttpGet("{id}", Name = "GetMovie")]
    public ActionResult<Movie> GetById(long id)
    {
        var item = _context.Movies.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

    // POST: api/Movies
    [HttpPost]
    public IActionResult Create(Movie item)
    {
        _context.Movies.Add(item);
        _context.SaveChanges();

        return CreatedAtRoute("GetMovie", new { id = item.Id }, item);
    }

    // PUT: api/Movies/5
    [HttpPut("{id}")]
    public IActionResult Update(long id, Movie item)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }

        movie.Name = item.Name;
        movie.ReleaseDate = item.ReleaseDate;
        movie.Genre = item.Genre;
        movie.Price = item.Price;

        _context.Movies.Update(movie);
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Movies/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(Convert.ToInt32(id));
        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}