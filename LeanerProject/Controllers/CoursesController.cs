﻿using LeanerProject.Models;
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

        void dropDowonLoad()
        {
            var CategoriesList = _context.Categories.Where(x => x.Status == true).ToList();

            List<SelectListItem> dropDownList = (from x in CategoriesList
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = dropDownList;
        }


        [HttpGet]
        public ActionResult CourseDetail(int id)
        {
            var value = _context.Courses.Include(x => x.Category).FirstOrDefault(t => t.CourseId == id);
            dropDowonLoad();
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
            return RedirectToAction("../Courses/Index");
        }


        public ActionResult DeleteCourse(int id)
        {
            var value = _context.Courses.Find(id);
            _context.Courses.Remove(value);
            _context.SaveChanges();
            TempData["Result"] = "Kayıt Silindi.";
            return RedirectToAction("../Courses/Index");
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            dropDowonLoad();
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            TempData["Result"] = "Kayıt Eklendi";
            return RedirectToAction("../Courses/Index");

        }


        [HttpPost]
        public ActionResult SearchCourse(string courseName)
        {
            var value = _context.Courses.Where(x=>x.CourseName.ToLower().Contains(courseName.ToLower())).ToList();
            TempData["SearchValue"] = value;
            return View("Index", value);
        }
    }
}