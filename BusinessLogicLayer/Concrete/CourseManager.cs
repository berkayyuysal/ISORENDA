using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CourseValidator))]
        public IResult Add(Course course)
        {
            var result = BusinessRules.Run(CheckIsCourseExists(course.Name));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _courseDal.Add(course);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CourseValidator))]
        public IResult Update(Course course)
        {
            _courseDal.Update(course);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CourseValidator))]
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

        public IDataResult<List<Course>> GetActiveCourses()
        {
            var result = _courseDal.GetAll(c => c.Status==true);
            if (result != null)
            {
                return new SuccessDataResult<List<Course>>(result);
            }
            return new ErrorDataResult<List<Course>>();
        }

        public IDataResult<Course> GetActiveCourseById(Guid courseId)
        {
            var result = _courseDal.GetOne(c => c.CourseId == courseId && c.Status == true);
            if (result != null)
            {
                return new SuccessDataResult<Course>(result);
            }
            return new ErrorDataResult<Course>();
        }

        private IResult CheckIsCourseExists(string courseName)
        {
            var result = _courseDal.GetOne(c => c.Name == courseName);
            if (result != null)
            {
                return new ErrorResult("Course already exists!");
            }
            return new SuccessResult();
        }
    }
}
