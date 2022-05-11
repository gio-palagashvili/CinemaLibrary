using System.Collections.Generic;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaLibraryWebApp.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Actor> objActorList = _db.Actors;

            return View(objActorList);
        }
    }
}