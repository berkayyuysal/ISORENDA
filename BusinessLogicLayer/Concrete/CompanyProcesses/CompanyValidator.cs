using System;
using Core.Entities.Concrete;
using FluentValidation;

namespace BusinessLogicLayer.Concrete.CompanyProcesses
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.TaxNumber).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
