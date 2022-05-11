using System;
using Core.Entities.Concrete;
using FluentValidation;

namespace BusinessLogicLayer.Concrete.ClientProcesses
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.IdentityNumber).NotEmpty();
            RuleFor(c => c.Gender).NotNull();
            RuleFor(c => c.MartialStatus).NotNull();
            RuleFor(c => c.RealBirthDate).NotEmpty();
            RuleFor(c => c.BirthDateOnIdentity).NotEmpty();
        }
    }
}
