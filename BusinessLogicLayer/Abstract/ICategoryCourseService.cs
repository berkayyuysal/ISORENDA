using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ICategoryCourseService
    {
        IResult Add(CategoryCourse categoryCourse, Course course, List<Guid> categoryIds);
        IResult Update(CategoryCourse categoryCourse, List<Guid> categoryIds);
        IResult Delete(CategoryCourse categoryCourse);
        IDataResult<List<CategoryCourse>> GetCategoryCourses();
        IDataResult<CategoryCourse> GetCategoryCourseById(Guid categoryCourseId);
    }
}
