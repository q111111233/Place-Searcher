using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaceSearch.Models;
using System.Linq;

namespace PlaceSearch.Controllers
{
    public class PlacesController : Controller
    {
        private PlaceSearchContext db = new PlaceSearchContext();
        public IActionResult Index()
        {
            return View(db.Places.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Place place)
        {
            db.Places.Add(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        [HttpPost]
        public IActionResult Edit(Place place)
        {
            db.Entry(place).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(places => places.PlaceId == id);
            db.Places.Remove(thisPlace);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}