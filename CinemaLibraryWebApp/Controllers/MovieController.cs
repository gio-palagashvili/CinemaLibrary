using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaLibraryWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string genre, int imdb,float rt,string date)
        {
            IEnumerable<Movie> objActorList = _db.Movies.Include(x => x.Genre);

            if (genre != null)
            {
                objActorList = objActorList.Where(x => x.Genre.Name == genre);
            }
            if (imdb > 1)
            {
                objActorList = objActorList.Where(x => x.IMDB >= imdb);
            }
            if (rt > 1)
            {
                objActorList = objActorList.Where(x => x.RottenTomatoes >= rt);
            }
            if (date != null)
            {
                DateTime dateTime = DateTime.Parse(date);
                objActorList = objActorList.Where(x =>
                {
                    var b = (x.ReleaseDate - dateTime).TotalDays > 0;
                    return b;
                });
            }

            var user = _db.Users.FirstOrDefault(x => x.Id == HttpContext.Session.GetInt32("userId"));
            
            ViewBag.Movies = objActorList;
            
            if (user != null) ViewBag.UserRole = user.Role;

            return View(ViewBag);
        }
        public IActionResult Details(int id)
        {
            Movie movie = _db.Movies
                    .Include(e => e.Actors)
                    .Include(e => e.Director)
                    .Include(e => e.Genre).FirstOrDefault(e => e.Id == id);

            ViewBag.Movie = movie;
            ViewBag.C = _db.Comments.First();

            return View(ViewBag);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Movie movie = _db.Movies.Find(id);
            if (movie == null) return NotFound("error");
            _db.Remove(movie);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {

            if (HttpContext.Session.GetString("userRole") != "admin") return RedirectToAction("Index", "Movie");

            var movie = _db.Movies.Include(e => e.Genre).Include(e => e.Director).FirstOrDefault(x => x.Id == id);
            ViewBag.Movie = movie;
            ViewBag.Genres = _db.Genres;
            
            return View(ViewBag);
        }
        [HttpPost]
        public IActionResult Edit(int Id,string Name, DateTime ReleaseDate, float IMDB, 
            float RottenTomatoes, string Poster, int Genre, string Description)
        {
            Genre genre = _db.Genres.FirstOrDefault(x => x.Id == Genre);

            var movie = new Movie { Id=Id,Description = Description,Poster = Poster,ReleaseDate = ReleaseDate,Name = Name,
                IMDB = IMDB,RottenTomatoes = RottenTomatoes, Genre = genre};
            
            _db.Movies.Update(movie);
            _db.SaveChanges();
            
            return RedirectToAction("Edit");
        }
    }
}