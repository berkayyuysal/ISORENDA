using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface ITeacherService
    {
        IResult AddTeacher(Teacher teacher);
    }
}
