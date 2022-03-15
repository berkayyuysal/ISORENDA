using System;
using Core.CrossCuttingConcerns.Validation;
using Entities.DTOs;
using FluentValidation;

namespace BusinessLogicLayer.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Username).NotEmpty();
        }
    }
}
