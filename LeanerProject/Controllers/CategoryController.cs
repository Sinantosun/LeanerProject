using FluentValidation.Results;
using LeanerProject.Models;
using LeanerProject.ValidationRules.CategoryRules;
using LearnerProject.Models.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using LeanerProject.Models.Entities;
using System.Collections.Generic;

namespace LeanerProject.Controllers
{
    public class CategoryController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            if (TempData["IconId"] != null)
            {
                TempData["IconId"] = null;
            }

            var value = _context.Categories.Include(x => x.CategoryIcons).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCategory(int pageNumber = 1, string status = "")
        {
            if (status == "active")
            {
                TempData["pagenumber"] = pageNumber;
            }
            var list = _context.CategoryIcons.ToList().ToPagedList(pageNumber, 90);
            return View(list);
        }

        IPagedList<CategoryIcons> GetCategoryIconsList()
        {
            var list = _context.CategoryIcons.ToList().ToPagedList(1, 90);
            return list;
        }


        public JsonResult SearchData(string IconName)
        {
            var finIconName = _context.CategoryIcons.ToList().Where(x => x.IconType.Contains(IconName));
        
            
            return Json(finIconName, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChooseIcon(string resultData)
        {
            var value = _context.CategoryIcons.FirstOrDefault(x => x.IconType == resultData);
            if (value != null)
            {
                TempData["IconId"] = value.CategoryIconsID.ToString();
               
                return Json(value.CategoryIconsID, JsonRequestBehavior.AllowGet);
            }
            return Json("err", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (TempData["IconId"] == null)
            {
                var result = "Lütfen İkon Seçiniz";
                TempData["Result"] = result;
                return View(GetCategoryIconsList());
            }
            else
            {
                int IconId = Convert.ToInt32(TempData["IconId"]);
                category.CategoryIconsID = IconId;
                CreateCategoryValidator validationRules = new CreateCategoryValidator();
                ValidationResult validationResult = validationRules.Validate(category);
                if (validationResult.IsValid)
                {
                    _context.Categories.Add(new Category()
                    {
                        CategoryIconsID = IconId,
                        CategoryName = category.CategoryName,
                        Status = true,

                    });
                    _context.SaveChanges();
                    TempData["Result"] = "Kayıt Eklendi";
                    return RedirectToAction("Index");
                }
                else
                {
                    var result = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                    TempData["Result"] = result;

                    return View(GetCategoryIconsList());
                }
            }


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

        [HttpGet]
        public ActionResult UpdateCategory(int id, int pageNumber = 1, string status = "")
        {
            if (status == "active")
            {
                TempData["pagenumber"] = pageNumber;
            }
            var value = _context.Categories.Find(id);
            var list = _context.CategoryIcons.ToList().ToPagedList(pageNumber, 90);
            ViewBag.V = list;
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            int id = 0;
           

            var value = _context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            if (TempData["IconId"] != null)
            {
                id = Convert.ToInt32(TempData["IconId"]);
                value.CategoryIconsID = id;
            }
            _context.SaveChanges();

            TempData["Result"] = "Güncellendi.";
            return RedirectToAction("Index");

        }

        public PartialViewResult _IconsPartial()
        {

            var list = _context.CategoryIcons.ToList().ToPagedList(1, 90);
            return PartialView(list);
        }



    }
}