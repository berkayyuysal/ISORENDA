using System;
using Core.Entities.Concrete;
using FluentValidation;

namespace BusinessLogicLayer.Concrete.ParentProcesses
{
    public class ParentValidator : AbstractValidator<Parent>
    {
        public ParentValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.IdentityNumber).NotEmpty();
            RuleFor(p => p.Gender).NotNull();
            RuleFor(p => p.MaritalStatus).NotNull();
            RuleFor(p => p.RealBirthDate).NotEmpty();
            RuleFor(p => p.BirthDateOnIdentity).NotEmpty();
        }
    }
}
