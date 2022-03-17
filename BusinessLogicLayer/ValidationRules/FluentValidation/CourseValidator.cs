using System;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace BusinessLogicLayer.ValidationRules.FluentValidation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
