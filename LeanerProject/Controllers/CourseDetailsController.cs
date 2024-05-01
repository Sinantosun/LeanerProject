using LeanerProject.DAL.Repositoryies;
using LeanerProject.Models;
using LearnerProject.Models.Entities;
using Newtonsoft.Json.Linq;
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


        bool IsRegistred(int courseId)
        {
            if (Session["StudentName"] != null)
            {
                var session = Session["StudentName"].ToString();
                var value = _context.Students.FirstOrDefault(x => x.NameSurname == session.ToString()).StudentId;
                var IsApprove = _context.CourseRegisters.FirstOrDefault(x => x.CourseId == courseId && x.StudentId == value);
                if (IsApprove != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        Course Datas(int id)
        {
            var value = _courseRepository.getListCourseWithReview(id);
            var videoCountById = _courseRepository.getCourseVideoCount(id);
            ViewBag.VideoCount = videoCountById;
            return value;
        }


        [HttpGet]
        public ActionResult Index(int id)
        {
            var value = Datas(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult RegisterCourse(int id)
        {
            var lists = _courseRepository.getListCourseWithReview(id);

            if (Session["StudentName"] == null)
            {
                TempData["userResult"] = "giriş yapmadan devam edilemez.";
                TempData["userResultIcon"] = "warning";
                TempData["userResultTitle"] = "Hata";
            }
            else
            {

                var session = Session["StudentName"].ToString();
                var value = _context.Students.FirstOrDefault(x => x.NameSurname == session.ToString()).StudentId;
                var IsApprove = _context.CourseRegisters.FirstOrDefault(x => x.CourseId == id && x.StudentId == value);
                if (IsApprove == null)
                {
                    _context.CourseRegisters.Add(new CourseRegister
                    {
                        CourseId = id,
                        StudentId = value
                    });
                    _context.SaveChanges();
                    TempData["userResult"] = "Bu kursa kayıt oldunuz. ilerlemenizi öğrenci panelinizden takip edebilirisinz.!!";
                    TempData["userResultIcon"] = "success";
                    TempData["userResultTitle"] = "Tebrikler!! 🎉🎉 ";
                }


            }
            return RedirectToAction("../CourseDetails/Index/"+id);



        }
        public PartialViewResult UICourseDetailPartial(int id)
        {
            var values = _context.CoursesDetails.Where(x => x.CourseId == id).ToList();
            return PartialView(values);
        }
        public PartialViewResult UIDetailPartial(int id)
        {
            var values = _context.CoursesDetails.Where(x => x.CourseId == id).ToList();
            return PartialView(values);
        }
        [HttpPost]
        public ActionResult Index(Review review)
        {
            var value = Datas(review.CourseId);
            if (Session["StudentName"] != null)
            {

                var IsApprevd = IsRegistred(review.CourseId);
                if (IsApprevd)
                {
                    string session = Session["StudentName"].ToString();
                    var IsApprove = _context.Reviews.FirstOrDefault(x => x.Student.NameSurname == session.ToString() && x.CourseId == review.CourseId);
                    if (IsApprove == null)
                    {
                        var id = _context.Students.FirstOrDefault(x => x.NameSurname == session).StudentId;
                        review.CourseId = review.CourseId;
                        review.StudentId = id;
                        _context.Reviews.Add(review);
                        _context.SaveChanges();
                    }
                    else
                    {
                        TempData["result"] = "Bu kursa zaten değerlendirme yaptınız, lütfen öğrenci panelinizden yormununuzu güncelleyin.";
                    }
                }
                else
                {
                    TempData["result"] = "Bu kursa henüz kayıt olmadınız. kayıt olduktan sonra kursa yorum yapabilirsiniz. lütfen kurs kaydını gerçekleştirdikten sonra tekrar deneyin.";
                }
                

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