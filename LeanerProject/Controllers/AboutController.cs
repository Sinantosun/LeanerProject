using FluentValidation.Results;
using LeanerProject.DAL;
using LeanerProject.Models;
using LeanerProject.ValidationRules.AboutRules;
using LearnerProject.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class AboutController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {

            if (TempData["AboutId"] != null)
            {
                TempData["AboutId"] = null;
            }
            var value = _context.Abouts.ToList();
            return View(value);
        }
        public JsonResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            var status = _context.SaveChanges();

            if (status > 0)
            {


                TempData["Result"] = value.Title + " Başlıklı Kayıt Silindi.";
                return Json("");
            }
            else
            {
                TempData["Result"] = "kayıt silinirken bir hata meydana geldi.";
                return Json("");
            }
        }

        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {

           

                CreateAboutValidator validationRules = new CreateAboutValidator();
                ValidationResult validationResult = validationRules.Validate(about);
                if (validationResult.IsValid)
                {
                    _context.Abouts.Add(about);
                    var InsertStatus = _context.SaveChanges();
                    if (InsertStatus > 0)
                    {
                        TempData["Result"] = "Yeni Kayıt Eklendi";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Result"] = "Bir hata oluştu kayıt eklenemedi.";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    var result = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                    TempData["Result"] = result;
                    return View();
                }
        }







        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            TempData["AboutId"] = id;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            CreateAboutValidator validationRules = new CreateAboutValidator();
            ValidationResult validationResult = validationRules.Validate(about);
            int _id = Convert.ToInt32(TempData["AboutId"]);
            var value = _context.Abouts.Find(_id);
            if (validationResult.IsValid)
            {

                if (_id == about.AboutId)
                {

                    value.Description = about.Description;
                    value.Item1 = about.Item1;
                    value.Item2 = about.Item2;
                    value.Item3 = about.Item3;
                    value.Title = about.Title;
                    var updateStatus = _context.SaveChanges();
                    if (updateStatus > 0)
                    {

                        TempData["Result"] = "Kayıt Güncellendi.";
                        return RedirectToAction("Index");
                    }
                    else if (updateStatus == 0)
                    {
                        TempData["Result"] = "Lütfen En az bir kaydı güncelleştirin. Kayıtlarda değişiklik yapmadınız.";
                    }
                    TempData["AboutId"] = _id;
                    return View(value);

                }
                else
                {
                    TempData["Result"] = "Geçersiz İşlem";
                    TempData["AboutId"] = _id;
                    return View(value);
                }
            }
            else
            {
                var result = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                TempData["Result"] = result;
                TempData["AboutId"] = _id;
                return View(value);
            }



        }
    }
}