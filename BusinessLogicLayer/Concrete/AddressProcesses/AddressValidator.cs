using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete.AddressProcesses
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
