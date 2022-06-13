using System;
using System.Collections.Generic;
using System.Linq;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Http;
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

            ViewBag.directors = objActorList;
            ViewBag.userRole = HttpContext.Session.GetString("userRole");
            
            return View(ViewBag);
        }
        public IActionResult Details(int id)
        {
            Director director = _db.Directors.FirstOrDefault(director1 => director1.Id == id);
            IEnumerable<Movie> movies = _db.Movies.Where(movie => movie.Director.Id == id);
            
            ViewBag.director = director;
            ViewBag.movies = movies;
            ViewBag.userRole = HttpContext.Session.GetString("userRole");

            return View(ViewBag);
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
            ViewBag.director = dir;
            ViewBag.userRole = HttpContext.Session.GetString("userRole");
            if (HttpContext.Session.GetString("userRole") != "admin")
            {
                return RedirectToAction("Index", "Auth");
            }
            return View(ViewBag);
        }
        [HttpPost]
        public IActionResult Edit(int id,string Name,string LastName,DateTime BirthDate, float Rating, string Portrait)
        {
            if (HttpContext.Session.GetString("userRole") != "admin")
            {
                return RedirectToAction("Index", "Auth");
            }
            
            Director director = new Director { Id = id,Name = Name,Portrait = Portrait,Rating = Rating,BirthDate = BirthDate,LastName = LastName};
            _db.Directors.Update(director);
            _db.SaveChanges();

            return View(director);
        }
    }
}