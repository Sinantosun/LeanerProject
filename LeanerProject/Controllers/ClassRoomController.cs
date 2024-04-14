using LeanerProject.Models;
using PagedList;
using System;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;
using LeanerProject.DAL.CategoryIconsDal;
using LeanerProject.ValidationRules.ClassRoomRules;
using FluentValidation.Results;
using System.Data.Entity;

namespace LeanerProject.Controllers
{
    public class ClassRoomController : Controller
    {
        Context _context = new Context();
        CategoryIconsManager CategoryIconsManager = new CategoryIconsManager();
        public ActionResult Index()
        {
            if (TempData["IconId"] != null)
            {
                TempData["IconId"] = null;
            }
            var value = _context.ClassRooms.Include(y => y.CategoryIcons).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddClassRoom(int pageNumber = 1, string status = "")
        {
            if (status == "active")
            {
                TempData["pagenumber"] = pageNumber;
            }
            var value = CategoryIconsManager.GetCategoryIconsList(pageNumber);
            return View(value);
        }

        [HttpPost]
        public ActionResult AddClassRoom(Classroom classroom)
        {
            var value = CategoryIconsManager.GetCategoryIconsList(1);
            if (TempData["IconId"] == null)
            {
                TempData["Result"] = "Lütfen ikon seçiniz.";
                return View(value);
            }
            else
            {
                int IconId = Convert.ToInt32(TempData["IconId"]);
                classroom.CategoryIconsID = IconId;
                CreateClassRoomValidator validationRules = new CreateClassRoomValidator();
                ValidationResult validationResult = validationRules.Validate(classroom);
                if (validationResult.IsValid)
                {
                    _context.ClassRooms.Add(classroom);
                    _context.SaveChanges();
                    TempData["Result"] = "Yenı Kayıt Eklendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    var err = string.Join("<br>", validationResult.Errors.Select(y => y.ErrorMessage));
                    TempData["Result"] = err;
                    return View(value);
                }

            }
        }

        [HttpGet]
        public ActionResult UpdateClassRoom(int id, int pageNumber = 1, string status = "")
        {
            if (status=="active")
            {
                TempData["pagenumber"] = pageNumber;
            }

            var value = _context.ClassRooms.Find(id);
            var list = _context.CategoryIcons.ToList().ToPagedList(pageNumber, 90);
            ViewBag.V = list;
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateClassRoom(Classroom classroom)
        {

            var value = _context.ClassRooms.Find(classroom.ClassroomId);
            value.Description = classroom.Description;
            value.Name = classroom.Name;
            if (TempData["IconId"] != null)
            {
                int id = Convert.ToInt32(TempData["IconId"]);
                value.CategoryIconsID = id;
            }
            _context.SaveChanges();
            TempData["Result"] = "Kayıt Güncellendi.";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClassRoom(int id)
        {
            var value = _context.ClassRooms.Find(id);
            _context.ClassRooms.Remove(value);
            _context.SaveChanges();
            TempData["Result"] = "İlgili kayıt silindi.";
            return RedirectToAction("Index");
        }

        public PartialViewResult _IconsPartial()
        {
            var list = _context.CategoryIcons.ToList().ToPagedList(1, 90);
            return PartialView(list);
        }

    }
}