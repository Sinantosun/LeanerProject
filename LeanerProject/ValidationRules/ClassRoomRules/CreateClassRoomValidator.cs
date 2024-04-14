

using FluentValidation;
using LearnerProject.Models.Entities;

namespace LeanerProject.ValidationRules.ClassRoomRules
{
    public class CreateClassRoomValidator:AbstractValidator<Classroom>
    {
        public CreateClassRoomValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Açıklama Alanı Maxiumum 100 karakter içermelidir.");

            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Sınıf Ad Alanı Maxiumum 50 karakter içermelidir.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Sınıf Ad Alanı Boş Geçilemez.");

            RuleFor(x => x.CategoryIconsID).NotEmpty().WithMessage("İkonu Seçmediniz.. Lütfen İkon Seçiniz.");
       
        }
    }
}