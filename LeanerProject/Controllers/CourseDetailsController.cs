using LeanerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class CourseDetailsController : Controller
    {
        Context _context = new Context();
        

        [HttpGet]
        public ActionResult Index(int id)
        {
            var value = _context.Courses.Include(x => x.Reviews).FirstOrDefault(x => x.CourseId == id);
            var videoCountById = _context.courseVideos.Where(x => x.CourseId == id).Count();
            ViewBag.VideoCount = videoCountById;
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Review review)
        {

            review.CourseId = review.CourseId;
            review.StudentId = 2;
            _context.Reviews.Add(review);
            _context.SaveChanges();

            var value = _context.Courses.Include(x => x.Reviews).FirstOrDefault(x => x.CourseId == review.CourseId);
            var videoCountById = _context.courseVideos.Where(x => x.CourseId == review.CourseId).Count();
            ViewBag.VideoCount = videoCountById;
            return View(value);
        }

        public PartialViewResult Comments(int id)
        {
            var value = _context.Reviews.Where(x => x.CourseId == id).ToList();
            return PartialView(value);
        }
    }
}