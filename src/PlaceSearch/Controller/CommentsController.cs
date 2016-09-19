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
        private readonly ApplicationDbContext _db;

        public CommentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Comments.Include(comments => comments.Place).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }
        public IActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(_db.Places, "PlaceId", "PlaceName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            ViewBag.PlaceId = new SelectList(_db.Places, "PlaceId", "PlaceName");
            return View(thisComment);
        }

        [HttpPost]
        public IActionResult Edit(Comment comment)
        {
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            _db.Comments.Remove(thisComment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
