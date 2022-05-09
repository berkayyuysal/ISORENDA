using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using FluentValidation;

namespace BusinessLogicLayer.Concrete.AuthenticateRoleProcesses
{
    public class AuthenticateRoleValidator : AbstractValidator<AuthenticateRole>
    {
        public AuthenticateRoleValidator()
        {
            RuleFor(a => a.AuthenticateId).NotEmpty();
            RuleFor(a => a.RoleId).NotEmpty();
        }
    }
}
