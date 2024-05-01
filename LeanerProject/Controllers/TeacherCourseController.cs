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
        Context _context = new Context();
        public ActionResult Index()
        {


            var values = _context.Courses.Where(x => x.Teacher.NameSurname == "Murat Yücedağ").Include(x => x.CoursesDetails).ToList();
            return View(values);
        }

        void listitem()
        {
            var value = _context.Courses.Where(x => x.TeacherID == 2).ToList();
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
            var CategoriesList = _context.Courses.Where(x => x.Teacher.TeacherID == 2).ToList();

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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
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
            // string name = Session["teacherName"].ToString();
            //course.TeacherID = _context.teachers.Where(x => x.NameSurname == name).Select(y => y.TeacherID).FirstOrDefault();
            course.TeacherID = 1;
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
            int Id = Convert.ToInt32(Session["teacherId"].ToString());
            var values = _context.Courses.Find(course.CourseId);
            values.TeacherID = _context.teachers.Where(x => x.TeacherID == Id).Select(y => y.TeacherID).FirstOrDefault();
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