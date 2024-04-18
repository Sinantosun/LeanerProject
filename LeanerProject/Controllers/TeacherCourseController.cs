using LeanerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class TeacherCourseController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            
            string name = Session["teacherName"].ToString();
            var values = _context.Courses.Where(x => x.Teacher.NameSurname == name).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            var CategoriesList = _context.Categories.Where(x => x.Status == true).ToList();

            List<SelectListItem> dropDownList = (from x in CategoriesList
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = dropDownList;
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            string name = Session["teacherName"].ToString();
            course.TeacherID = _context.teachers.Where(x => x.NameSurname == name).Select(y => y.TeacherID).FirstOrDefault();
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            var CategoriesList = _context.Categories.Where(x => x.Status == true).ToList();

            List<SelectListItem> dropDownList = (from x in CategoriesList
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = dropDownList;


            var values = _context.Courses.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            string name = Session["teacherName"].ToString();
            var values = _context.Courses.Find(course.CourseId);
            values.TeacherID = _context.teachers.Where(x => x.NameSurname == name).Select(y => y.TeacherID).FirstOrDefault();
            values.CourseName = course.CourseName;
            values.CategoryId = course.CategoryId;
            values.Price = course.Price;
            values.ImageUrl = course.ImageUrl;
            values.Description = course.Description;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCourse(int id)
        {
            var values = _context.Courses.Find(id);
            _context.Courses.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}