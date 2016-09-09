using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaceSearch.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlaceSearch.controller
{
    public class CommentsController : Controller
    {
        private PlaceSearchContext db = new PlaceSearchContext();
        public IActionResult Index()
        {
            return View(db.Comments.Include(comments => comments.Place).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }
        public IActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName");
            return View(thisComment);
        }

        [HttpPost]
        public IActionResult Edit(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            db.Comments.Remove(thisComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
