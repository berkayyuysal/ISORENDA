using System;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace BusinessLogicLayer.ValidationRules.FluentValidation
{
    public class FileValidator : AbstractValidator<File>
    {
        public FileValidator()
        {
            RuleFor(f => f.Name).NotEmpty();
            RuleFor(f => f.Path).NotEmpty();
        }
    }
}
