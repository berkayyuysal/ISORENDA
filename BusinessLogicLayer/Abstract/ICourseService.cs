using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ICourseService
    {
        IResult Add(Course course);
        IResult Update(Course course);
        IResult Delete(Course course);
        IDataResult<List<Course>> GetCourses();
        IDataResult<List<Course>> GetActiveCourses();
        IDataResult<Course> GetCourseById(Guid courseId);
        IDataResult<Course> GetActiveCourseById(Guid courseId);
    }
}
