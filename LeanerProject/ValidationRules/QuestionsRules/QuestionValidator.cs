using FluentValidation;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.ValidationRules.QuestionsRules
{
    public class QuestionValidator : AbstractValidator<FAQ>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Cevap Alanı Boş Geçilemez");
            RuleFor(x => x.Question).NotEmpty().WithMessage("Soru Alanı Boş Geçilemez");
        }
    }
}