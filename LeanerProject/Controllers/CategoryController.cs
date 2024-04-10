using LeanerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class CategoryController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var value = _context.Categories.Include(x => x.CategoryIcons).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        public JsonResult LoadData()
        {
            var list = _context.CategoryIcons.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchData(string IconName)
        {

            var list = _context.CategoryIcons.Where(x => x.IconType.Contains(IconName));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FindData(string resultData)
        {
            var value = _context.CategoryIcons.FirstOrDefault(x => x.IconType == resultData);
            if (value != null)
            {
                return Json(value.CategoryIconsID,JsonRequestBehavior.AllowGet);
            }
            return Json("err",JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
          
            _context.Categories.Add(new Category()
            {
                CategoryIconsID = category.CategoryIconsID,
                CategoryName = category.CategoryName,
                Status = true,

            });
            _context.SaveChanges();
            TempData["Result"] = "Kayıt Eklendi";
            return RedirectToAction("Index");
              
        


        }
        public ActionResult ChangeCategoryStatus(int id)
        {
            var value = _context.Categories.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}