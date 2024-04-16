using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class DashboardController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            ViewBag.CoursesCount = _context.Courses.Count();
            ViewBag.CategoryCount = _context.Categories.Where(x => x.Status == true).Count();
            ViewBag.ClassRoomCount = _context.ClassRooms.Count();
            ViewBag.RegisteredCount = _context.Students.Count();
            ViewBag.ExpensiveCourseName = _context.Courses.OrderByDescending(x => x.Price).Select(x => x.CourseName).FirstOrDefault();
            ViewBag.CheapCourseName = _context.Courses.OrderBy(x => x.Price).Select(y => y.CourseName).FirstOrDefault();
            ViewBag.CheapCourseName = _context.Courses.OrderBy(x => x.Price).Select(y => y.CourseName).FirstOrDefault();
            ViewBag.CourseAvgPrice = _context.Courses.Average(y => y.Price);





            ViewBag.HightReviewName = _context.Reviews.OrderByDescending(x => x.ReviewValue).Select(y => y.Course.CourseName).FirstOrDefault();


            var course1 = _context.Reviews.Where(x => x.Course.Category.CategoryName == "Kodlama").ToList();
            if (course1.Count != 0)
            {
                ViewBag.CourseAvgCoding = course1.Average(y => y.ReviewValue);
                ViewBag.CourseCodingCount = course1.Count();
            }
            else
            {
                ViewBag.CourseAvgCoding = 0;
                ViewBag.CourseCodingCount = "0";
            }

            var course2 = _context.Reviews.Where(x => x.Course.Category.CategoryName == "Grafik Tasarım").ToList();
            if (course2.Count != 0)
            {
                ViewBag.CourseAvgGraphic = course2.Average(y => y.ReviewValue);
                ViewBag.CourseGraphicCount = course2.Count();
            }
            else
            {
                ViewBag.CourseAvgGraphic = 0;
                ViewBag.CourseGraphicCount = "0";
            }

            var course3 = _context.Reviews.Where(x => x.Course.Category.CategoryName == "Fotoğrafcılık").ToList();
            if (course3.Count != 0)
            {
                ViewBag.CourseAvgPhoto = course3.Average(y => y.ReviewValue);
                ViewBag.CoursePhotoCount = course3.Count();
            }
            else
            {
                ViewBag.CourseAvgPhoto = 0;
                ViewBag.CoursePhotoCount = "0";
            }

            var course4 = _context.Reviews.Where(x => x.Course.Category.CategoryName == "İngilizce").ToList();
            if (course4.Count != 0)
            {
                ViewBag.CourseAvgEng = course4.Average(y => y.ReviewValue);
                ViewBag.CourseEngCount = course4.Count();
            }
            else
            {
                ViewBag.CourseAvgEng = 0;
                ViewBag.CourseEngCount = "0";
            }


            ViewBag.EngCount = _context.CourseRegisters.Where(x => x.Course.Category.CategoryName == "İngilizce").Count();
            ViewBag.CodingCount = _context.CourseRegisters.Where(x => x.Course.Category.CategoryName == "Kodlama").Count();
            ViewBag.PhotoCount = _context.CourseRegisters.Where(x => x.Course.Category.CategoryName == "Fotoğrafcılık").Count();
            ViewBag.GraphCount = _context.CourseRegisters.Where(x => x.Course.Category.CategoryName == "Grafik Tasarım").Count();
            return View();
        }
    }
}