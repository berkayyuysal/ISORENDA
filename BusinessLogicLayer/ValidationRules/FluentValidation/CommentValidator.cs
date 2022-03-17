using System;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace BusinessLogicLayer.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.CommentContent).NotEmpty();
        }
    }
}
