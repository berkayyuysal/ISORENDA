using System;
using Core.Entities.Concrete;
using FluentValidation;

namespace BusinessLogicLayer.Concrete.PostProcesses
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.PostContent).NotEmpty();
        }
    }
}
