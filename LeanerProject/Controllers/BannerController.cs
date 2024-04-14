using LeanerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class BannerController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var list = _context.Banner.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddBaner()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddBaner(Banner banner)
        {
            if (string.IsNullOrEmpty(banner.Title))
            {
                TempData["Result"] = "Lütfen Başlık Yazınız.";
                return View();
            }
            else
            {
                var value = _context.Banner.FirstOrDefault(x => x.Title == banner.Title);
                if (value != null)
                {
                    TempData["Result"] =  banner.Title + $" başlığı zaten kayıtlı lütfen güncelleme işlemi yapınız <br><br><a href='/Banner/UpdateBanner/{value.BannerId}' class='btn btn-danger'>Kaydı Güncelle</a>";
                    return View();
                }
                else
                {
                    _context.Banner.Add(banner);
                    _context.SaveChanges();
                    TempData["Result"] = "Yeni kayıt eklendi";
                    return RedirectToAction("Index");
                }
             
       
            }

        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = _context.Banner.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            var value = _context.Banner.Find(banner.BannerId);
            if (string.IsNullOrEmpty(banner.Title))
            {
                TempData["Result"] = "Lütfen başlık alanını doldurunuz.";
                return View(value);
            }
            else
            {
                value.Title = banner.Title;
                _context.SaveChanges();
                TempData["Result"] = "İligli kayıt güncellendi.";
                return RedirectToAction("Index");
            }
           
     

        }

        public ActionResult DeleteBanner(int id)
        {
            var value = _context.Banner.Find(id);
            _context.Banner.Remove(value);
            _context.SaveChanges();
            TempData["Result"] = "Değer Silidi";
            return RedirectToAction("Index");
        }



    }
}