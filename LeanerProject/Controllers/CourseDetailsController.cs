using LeanerProject.DAL.Repositoryies;
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
        CourseRepository _courseRepository = new CourseRepository();

        [HttpGet]
        public ActionResult Index(int id)
        {
            var value = _courseRepository.getListCourseWithReview(id);
            var videoCountById = _courseRepository.getCourseVideoCount(id);
            ViewBag.VideoCount = videoCountById;
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Review review)
        {
            var value = _courseRepository.getListCourseWithReview(review.CourseId);
            var videoCountById = _courseRepository.getCourseVideoCount(review.CourseId);
            ViewBag.VideoCount = videoCountById;
            if (Session["userStudentName"] != null)
            {
                review.CourseId = review.CourseId;
                review.StudentId = 2;
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return View(value);
            }
            else
            {
                TempData["session"] = "userNotFound";
                return View(value);
            }

        }

        public PartialViewResult Comments(int id)
        {
            var value = _context.Reviews.Where(x => x.CourseId == id).ToList();
            return PartialView(value);
        }
    }
}