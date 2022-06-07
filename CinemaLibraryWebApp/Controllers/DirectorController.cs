using System.Collections.Generic;
using System.Linq;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaLibraryWebApp.Controllers
{
    public class DirectorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DirectorController(ApplicationDbContext db)
        {
            _db = db;
        }        
        public IActionResult Index(float imdb)
        {
            IEnumerable<Director> objActorList = _db.Directors;
            if (imdb > 0)
            {
                objActorList = objActorList.Where(x => x.Rating >= imdb);
            }

            return View(objActorList);
        }
        public IActionResult Details(int id)
        {
            Director director = _db.Directors.FirstOrDefault(x => x.Id == id);
            IEnumerable<Movie> movies = _db.Movies.Where(x => x.Director.Id == id);
            DirectorMovie x = new DirectorMovie() {Director = director, movies = movies};

            return View(x);
        }
        
        
        public IActionResult Delete(int id)
        {
            Director dir = _db.Directors.Find(id);
            if (dir == null) return NotFound($"No director was found with id of {id}");
            _db.Directors.Remove(dir);
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Director dir = _db.Directors.Find(id);
            if (dir == null) return NotFound($"No director was found with id of {id}");

            return View(dir);
        }
        [HttpPost]
        public IActionResult Edit(Director director)
        {
            _db.Update(director);
            _db.SaveChanges();

            return View(director);
        }
    }
}