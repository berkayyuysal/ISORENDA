using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public IResult Add(Course course)
        {
            _courseDal.Add(course);
            return new SuccessResult();
        }

        public IResult Update(Course course)
        {
            _courseDal.Update(course);
            return new SuccessResult();
        }

        public IResult Delete(Course course)
        {
            course.Status = false;
            _courseDal.Update(course);
            return new SuccessResult();
        }
        public IDataResult<List<Course>> GetCourses()
        {
            var result = _courseDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Course>>(result);
            }
            return new ErrorDataResult<List<Course>>();
        }

        public IDataResult<Course> GetCourseById(Guid courseId)
        {
            var result = _courseDal.GetById(courseId);
            if (result != null)
            {
                return new SuccessDataResult<Course>(result);
            }
            return new ErrorDataResult<Course>();
        }

    }
}
