using FluentValidation;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.ValidationRules.AboutRules
{
    public class CreateAboutValidator:AbstractValidator<About>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama Alanı Maximumum 500 karakter içerebilir.");


            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Başlık Alanı Maxiumum 20 karakter içerebilir.");

            RuleFor(x => x.Item1).NotEmpty().WithMessage("Öğe 1 Alanı Boş Geçilemez");
            RuleFor(x => x.Item2).NotEmpty().WithMessage("Öğe 2 Alanı Boş Geçilemez");
            RuleFor(x => x.Item3).NotEmpty().WithMessage("Öğe 3 Alanı Boş Geçilemez");
        }
    }
}