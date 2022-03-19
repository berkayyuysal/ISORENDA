using System;
using Core.Entities.Concrete;
using FluentValidation;

namespace BusinessLogicLayer.Concrete.MentorProcesses
{
    public class MentorValidator : AbstractValidator<Mentor>
    {
        public MentorValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty();
            RuleFor(m => m.LastName).NotEmpty();
            RuleFor(m => m.IdentityNumber).NotEmpty();
            RuleFor(m => m.Gender).NotNull();
            RuleFor(m => m.MaritalStatus).NotNull();
            RuleFor(m => m.RealBirthDate).NotEmpty();
            RuleFor(m => m.BirthDateOnIdentity).NotEmpty();
        }
    }
}
