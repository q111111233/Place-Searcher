using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaceSearch.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaceSearch.controller
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string start_address, string end_address)
        {
            var allMaps = Map.GetMaps(start_address, end_address);
            Console.WriteLine(allMaps);
            ViewBag.allMaps = allMaps;
            return View();
        }
        public IActionResult PlaceList()
        {
            return View(_db.Places.ToList());
        }

        //public IActionResult SendMap()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult SendMap(Map newMap)
        //{
        //    newMap.Send();
        //    return RedirectToAction("Index");
        //}
    }
}
