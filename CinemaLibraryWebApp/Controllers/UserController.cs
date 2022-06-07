using CinemaLibraryWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaLibraryWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            ViewBag.users = HttpContext.Session.GetInt32("userId");
            return View(ViewBag);
        }
    }
}
