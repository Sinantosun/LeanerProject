using LeanerProject.Models;
using LeanerProject.Models.ViewModels;
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
            ViewBag.ExpensiveCourseName = _context.Courses.OrderByDescending(x => x.Price).Select(y => y.CourseName).FirstOrDefault();
            ViewBag.HightReviewName = _context.Reviews.OrderByDescending(x => x.ReviewValue).Select(y => y.Course.CourseName).FirstOrDefault();
            ViewBag.CheapCourseName = _context.Courses.OrderBy(x => x.Price).Select(y => y.CourseName).FirstOrDefault();
            ViewBag.CourseAvgPrice = _context.Courses.Average(y => y.Price);

            ViewBag.CoursesCount = _context.Courses.Count();
            ViewBag.CategoryCount = _context.Categories.Where(x => x.Status == true).Count();
            ViewBag.ClassRoomCount = _context.ClassRooms.Count();
            ViewBag.RegisteredCount = _context.Students.Count();
            return View();
        }

        public PartialViewResult DashboardIstatisticPartial()
        {
            List<DasboardViewModel> List = new List<DasboardViewModel>();
            var categoryName = _context.Categories.ToList();
            foreach (var item in categoryName)
            {
                var value = _context.Reviews.Where(x => x.Course.Category.CategoryName == item.CategoryName).ToList();
                string categoryAvg = "";
                if (value.Count != 0)
                {
                    categoryAvg = value.Average(x => x.ReviewValue).ToString();
                }
                else
                {
                    categoryAvg = "0";
                }
                List.Add(new DasboardViewModel
                {
                    CategoryName = item.CategoryName,
                    CategoryCount = (_context.Reviews.Count(x => x.Course.Category.CategoryName == item.CategoryName).ToString() == "0" ? "Henüz Değerlendirilmedi" : _context.Reviews.Count(x => x.Course.Category.CategoryName == item.CategoryName).ToString() + " Kayıt üzerinden Hesaplanmıştır"),
                    CategoryAvg = categoryAvg,

                });

            }


            return PartialView(List);
        }



        public PartialViewResult DashboardRegeisteredCourseCountPartial()
        {
            List<DashboardRegisterCountsViewModel> list = new List<DashboardRegisterCountsViewModel>();
            var values = _context.Categories.ToList();
            foreach (var item in values)
            {

                list.Add(new DashboardRegisterCountsViewModel
                {
                    CategoryName = item.CategoryName,
                    CategoryValue = _context.CourseRegisters.Count(x=>x.Course.Category.CategoryName==item.CategoryName).ToString(),
                });
            }


            return PartialView(list);
        }

    }
}