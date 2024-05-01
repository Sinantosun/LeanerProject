using LeanerProject.Models;
using LeanerProject.Models.Entities;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class TeacherCourseController : Controller
    {

        int Teacherid()
        {
            int _id = Convert.ToInt32(Session["teacherId"]);
            return _id;
        }


        Context _context = new Context();
        public ActionResult Index()
        {
            int id = Teacherid();
            var values = _context.Courses.Where(x => x.Teacher.TeacherID == id).Include(x => x.CoursesDetails).ToList();
            return View(values);
        }

        void listitem()
        {
            int id = Teacherid();
            var value = _context.Courses.Where(x => x.TeacherID == id).ToList();
            List<SelectListItem> list = (from x in value
                                         select new SelectListItem
                                         {
                                             Text = x.CourseName,
                                             Value = x.CourseId.ToString(),
                                         }).ToList();
            ViewBag.CourseList = list;
        }
        public ActionResult CourseVideosDetails(int id)
        {
            var values = _context.courseVideos.Where(x => x.CourseId == id).ToList();
            return View(values);
        }
        public ActionResult AddCourseVideo()
        {

            listitem();
            return View();
        }
        [HttpPost]
        public ActionResult AddCourseVideo(CourseVideo courseVideo)
        {

            _context.courseVideos.Add(courseVideo);
            _context.SaveChanges();
            listitem();

            return View();
        }
        [HttpGet]
        public ActionResult AddCourseDetail()
        {
            int id = Teacherid();
            var CategoriesList = _context.Courses.Where(x => x.Teacher.TeacherID == id).ToList();

            List<SelectListItem> dropDownList = (from x in CategoriesList
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CourseName,
                                                     Value = x.CourseId.ToString()
                                                 }).ToList();
            ViewBag.CourseList = dropDownList;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourseDetail(CoursesDetails coursesDetails)
        {
            _context.CoursesDetails.Add(coursesDetails);
            _context.SaveChanges();
            TempData["ResultSuccess"] = "Kurs Detayı Eklendi";
            return RedirectToAction("Index", "TeacherReviews");
        }

        [HttpGet]
        public ActionResult UpdateCourseDetail(int id)
        {

            var value = _context.CoursesDetails.FirstOrDefault(x => x.CourseId == id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCourseDetail(CoursesDetails coursesDetails)
        {
            var value = _context.CoursesDetails.Find(coursesDetails.CoursesDetailsID);
            value.CourseDetail = coursesDetails.CourseDetail;
            value.CourseContent = coursesDetails.CourseContent;
            _context.SaveChanges();
            TempData["ResultSuccess"] = "Kurs Detayı Güncellendi";
            return RedirectToAction("Index", "TeacherReviews");
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
            course.ImageUrl = "/Templates/learner-1.0.0/images/img-school-1-min.jpg";

            int id = Teacherid();
            course.TeacherID = id;
            _context.Courses.Add(course);
            _context.SaveChanges();
            TempData["ResultSuccess"] = "Kurs Eklendi";
            return RedirectToAction("Index", "TeacherReviews");
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
            int id = Teacherid();
            var values = _context.Courses.Find(course.CourseId);
            values.TeacherID = id;
            values.CourseName = course.CourseName;
            values.CategoryId = course.CategoryId;
            values.Price = course.Price;
            values.ImageUrl = course.ImageUrl;
            values.Description = course.Description;

            _context.SaveChanges();
            TempData["ResultSuccess"] = "Kurs Güncellendi";
            return RedirectToAction("Index", "TeacherReviews");
        }
        public ActionResult DeleteCourse(int id)
        {
            var values = _context.Courses.Find(id);
            _context.Courses.Remove(values);
            _context.SaveChanges();
            TempData["ResultSuccess"] = "Kurs Silindi";
            return RedirectToAction("Index", "TeacherReviews");
        }
    }
}