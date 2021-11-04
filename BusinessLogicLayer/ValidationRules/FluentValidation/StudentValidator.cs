using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ValidationRules.FluentValidation
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            //Name
            RuleFor(s => s.StudentName).NotEmpty();
            RuleFor(s => s.StudentName).MinimumLength(2);
            //RuleFor(s => s.StudentName).Must(StartWithA).WithMessage("Öğrenci adı A ile başlamalıdır."); -> Spesifik bir validation işlemi yapma.
            
            //Surname
            RuleFor(s => s.StudentSurname).NotEmpty();
            RuleFor(s => s.StudentSurname).MinimumLength(1);

            //Gender
            RuleFor(s => s.StudentGender).NotEmpty();

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
