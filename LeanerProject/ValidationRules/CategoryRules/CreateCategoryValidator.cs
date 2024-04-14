using FluentValidation;
using LearnerProject.Models.Entities;

namespace LeanerProject.ValidationRules.CategoryRules
{
    public class CreateCategoryValidator : AbstractValidator<Category>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryIconsID).NotEmpty().WithMessage("Lütfen ikon seçiniz.");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("kategori adı boş geçilemez.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithName("kategori adı");
        }
    }
}