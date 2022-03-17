using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.CityId).NotEmpty();
            RuleFor(a => a.TownId).NotEmpty();
            RuleFor(a => a.Detail).NotEmpty();
        }
    }
}
