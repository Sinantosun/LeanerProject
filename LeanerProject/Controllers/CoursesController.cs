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
    public class CoursesController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var value = _context.Courses.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CourseDetail(int id)
        {
            var value = _context.Courses.Include(x => x.Category).FirstOrDefault(t => t.CourseId == id);
            var CategoriesList = _context.Categories.ToList();

            List<SelectListItem> dropDownList = (from x in CategoriesList
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = dropDownList;



            return View(value);
        }
        [HttpPost]
        public ActionResult CourseDetail(Course course)
        {
            var value = _context.Courses.Find(course.CourseId);
            value.CourseName = course.CourseName;
            value.Description = course.Description;
            if (course.ImageUrl != null)
            {
                value.ImageUrl = course.ImageUrl;
            }
          
            value.Price = course.Price;
            value.CategoryId = course.CategoryId;
            _context.SaveChanges();
            TempData["Result"] = "Kayıt güncellendi.";
            return RedirectToAction("Index");
        }
    }
}