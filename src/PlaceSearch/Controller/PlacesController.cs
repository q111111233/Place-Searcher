using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaceSearch.Models;
using System.Linq;

namespace PlaceSearch.Controllers
{
    public class PlacesController : Controller
    {
        private ApplicationDbContext _db;

        public PlacesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Places.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisPlace = _db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Place place)
        {
            _db.Places.Add(place);
            _db.SaveChanges();
            return RedirectToAction("Index");
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