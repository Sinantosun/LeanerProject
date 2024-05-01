using FluentValidation;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.ValidationRules.ReviewRules
{
    public class ReviewValidator:AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            

        }
    }
}