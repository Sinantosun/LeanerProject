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
    public class StudentReviewsController : Controller
    {
        int StudentId()
        {
            return Convert.ToInt32(Session["StudentID"]);
        }


        Context _context = new Context();
        public ActionResult Index()
        {
            int id = StudentId();
            var value = _context.Reviews.Include(x => x.Course).Where(x => x.StudentId == id).ToList();

            return View(value);
        }
        [HttpGet]
        public ActionResult CreateReview()
        {
            int id = StudentId();
            var value = _context.CourseRegisters.Include(x => x.Course).Where(x => x.StudentId == id).ToList();

            List<SelectListItem> list = (from x in value
                                         select new SelectListItem
                                         {
                                             Text = x.Course.CourseName,
                                             Value = x.CourseId.ToString()
                                         }).ToList();

            ViewBag.CourseList = list;

            return View();
        }
        [HttpPost]
        public ActionResult CreateReview(Review review)
        {
            int id = StudentId();
            review.StudentId = id;
            _context.Reviews.Add(review);
            _context.SaveChanges();
            TempData["ResultSuccess"] = "Yorumunuz Eklendi";
            return RedirectToAction("Index", "StudentCourse");
        }
        [HttpGet]
        public ActionResult StudentReviewDetail(int id)
        {
            var value = _context.Reviews.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult StudentReviewDetail(Review review)
        {
            var value = _context.Reviews.Find(review.ReviewId);
            if (review.ReviewValue != 0)
            {
                value.ReviewValue = review.ReviewValue;
            }
            value.Comment = review.Comment;
            _context.SaveChanges();
            TempData["ResultSuccess"] = "Yorumunuz Güncellendi";
            return RedirectToAction("Index", "StudentCourse");
        }
        public ActionResult DeleteReview(int id)
        {
            var value = _context.Reviews.Find(id);
            _context.Reviews.Remove(value);
            _context.SaveChanges();
            TempData["ResultSuccess"] = "Yorumunuz Silindi.";
            return RedirectToAction("Index", "StudentCourse");
        }
    }
}