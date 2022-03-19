using System;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace BusinessLogicLayer.ValidationRules.FluentValidation
{
    public class DiscountValidator : AbstractValidator<Discount>
    {
        public DiscountValidator()
        {
            RuleFor(d => d.Percentage).NotEmpty();
            RuleFor(d => d.StartDate).NotEmpty();
            RuleFor(d => d.ExpirationDate).NotEmpty();

        }
    }
}
