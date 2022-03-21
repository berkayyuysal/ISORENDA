using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete.AuthenticateProcesses
{
    public class AuthenticateValidator : AbstractValidator<Authenticate>
    {
        public AuthenticateValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Description).NotEmpty();
        }
    }
}
