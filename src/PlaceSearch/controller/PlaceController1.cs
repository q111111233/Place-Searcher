using Microsoft.AspNetCore.Mvc;
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
    }
}