using System.Collections.Generic;
using System.Linq;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaLibraryWebApp.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(float imdb)
        {
            IEnumerable<Actor> objActorList = _db.Actors;
            if (imdb > 0)
            {
                objActorList = objActorList.Where(x => x.Rating >= imdb);
            }
            
            return View(objActorList);
        }
        public IActionResult Details(int id)
        {
            Actor actor;
            using (_db)
            {
                actor = _db.Actors.Include(e => e.Movies).Where(e => e.Id == id).FirstOrDefault();
            }
            return View(actor);
        }


        public IActionResult Delete(int id)
        {
            Actor actor = _db.Actors.Find(id);
            if (actor == null) return NotFound($"No Actor was found with id of {id}");
            _db.Actors.Remove(actor);
            _db.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Actor actor = _db.Actors.Find(id);
            if (actor == null) return NotFound($"No Actor was found with id of {id}");
            
            return View(actor);
        }
        [HttpPost]
        public IActionResult Edit(Actor actor)
        {
            _db.Update(actor);
            _db.SaveChanges();

            return View(actor);
        }
    }
}