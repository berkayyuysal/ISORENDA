using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface ICourseService
    {
        IResult AddCourse(Course course);
        IDataResult<List<Course>> GetAllCourses();
    }
}
