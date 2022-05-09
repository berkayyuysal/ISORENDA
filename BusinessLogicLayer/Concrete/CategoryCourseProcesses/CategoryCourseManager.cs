using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.CategoryCourseProcesses
{
    public class CategoryCourseManager : ICategoryCourseService
    {
        ICategoryCourseDal _categoryCourseDal;
        public CategoryCourseManager(ICategoryCourseDal categoryCourseDal)
        {
            _categoryCourseDal = categoryCourseDal;
        }

        public IResult Add(CategoryCourse categoryCourse, Course course, List<Guid> categoryIds)
        {
            foreach (var categoryId in categoryIds)
            {
                categoryCourse.CategoryId = categoryId;
                categoryCourse.CourseId = course.CourseId;
                _categoryCourseDal.Add(categoryCourse);
            }
            return new SuccessResult();
        }

        public IResult Update(CategoryCourse categoryCourse, List<Guid> categoryIds)
        {
            foreach (var categoryId in categoryIds)
            {
                categoryCourse.CategoryId = categoryId;
                categoryCourse.CourseId = categoryCourse.CourseId;
                _categoryCourseDal.Update(categoryCourse);
            }
            return new SuccessResult();
        }

        public IResult Delete(CategoryCourse categoryCourse)
        {
            _categoryCourseDal.Delete(categoryCourse);
            return new SuccessResult();
        }

        public IDataResult<List<CategoryCourse>> GetCategoryCourses()
        {
            var result = _categoryCourseDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<CategoryCourse>>(result);
            }
            return new ErrorDataResult<List<CategoryCourse>>(result);
        }

        public IDataResult<CategoryCourse> GetCategoryCourseById(Guid categoryCourseId)
        {
            var result = _categoryCourseDal.GetById(categoryCourseId);
            if (result != null)
            {
                return new SuccessDataResult<CategoryCourse>(result);
            }
            return new ErrorDataResult<CategoryCourse>(result);
        }
    }
}
