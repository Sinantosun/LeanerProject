using FluentValidation.Results;
using LeanerProject.Models;
using LeanerProject.ValidationRules.QuestionsRules;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class QuestionsController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var values = _context.FAQquestions.ToList();
            return View(values);
        }

        public ActionResult ChangeQuestionStatus(int id)
        {
            var value = _context.FAQquestions.Find(id);
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
        public ActionResult DeleteQuestions(int id)
        {
            var value = _context.FAQquestions.Find(id);
            _context.FAQquestions.Remove(value);
            _context.SaveChanges();
            TempData["Result"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddQuestions()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddQuestions(FAQ t)
        {

            QuestionValidator validationRules = new QuestionValidator();
            ValidationResult validationResult = validationRules.Validate(t);
            if (validationResult.IsValid)
            {
                t.Status = true;
                _context.FAQquestions.Add(t);
                _context.SaveChanges();
                TempData["Result"] = "Kayıt Eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                var err = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                TempData["Result"] = err;
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateQuestions(int id)
        {
            var value = _context.FAQquestions.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateQuestions(FAQ t)
        {

            QuestionValidator validationRules = new QuestionValidator();
            ValidationResult validationResult = validationRules.Validate(t);
            if (validationResult.IsValid)
            {
                t.Status = true;
                var value = _context.FAQquestions.Find(t.FAQId);
                value.Answer = t.Answer;
                value.Question = t.Question;
                TempData["Result"] = "Kayıt Güncellendi";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var err = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                TempData["Result"] = err;
                return View();
            }
        }
    }
}