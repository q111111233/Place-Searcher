using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaceSearch.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlaceSearch.Controllers
{
    [Authorize]
    public class PlacesController : Controller
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlacesController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Places.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult Details(int id)
        {
            var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string newName)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Place newPlace = new Place(newName, currentUser);
            _db.Places.Add(newPlace);
            _db.SaveChanges();
            return Json(newPlace);
        }
        public IActionResult Edit(int id)
        {
            var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        [HttpPost]
        public IActionResult Edit(Place place)
        {
            _db.Entry(place).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
            _db.Places.Remove(thisPlace);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}