using System;
using Core.CrossCuttingConcerns.Validation;
using Entities.DTOs;
using FluentValidation;

namespace BusinessLogicLayer.Concrete.AuthProcesses
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

    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty().When(u => u.Username == null);
            RuleFor(u => u.Username).NotEmpty().When(u => u.Email == null);
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
