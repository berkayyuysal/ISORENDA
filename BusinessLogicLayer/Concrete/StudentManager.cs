using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants.Messages;
using BusinessLogicLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;

namespace BusinessLogicLayer.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        [CacheAspect]
        public IDataResult<Student> GetStudentById(Guid id)
        {
            // İş kodları
            return new SuccessDataResult<Student>(_studentDal.GetOne(s => s.StudentId == id));
        }

        [CacheAspect]
        public IDataResult<List<Student>> GetAllStudents()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Student>>(ServerMessages.MaintenanceTime);
            }
            // İş kodları
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(), StudentMessages.StudentsListed);
        }

        //hello
        public IDataResult<List<Student>> GetStudentsByNameAndGender(Student student)
        {
            return new SuccessDataResult<List<Student>>
                (_studentDal.GetAll(s => s.StudentName == student.StudentName && s.StudentGender == student.StudentGender));
        }

        public IDataResult<List<StudentDetailDto>> GetStudentDetails()
        {
            return new SuccessDataResult<List<StudentDetailDto>>(_studentDal.GetStudentDetails());
        }

        //[SecuredOperation("admin")] -> OK
        [ValidationAspect(typeof(StudentValidator))] //-> OK
        //[CacheAspect(5)] -> OK Parameter is optional. If you dont send any parameter the parameter value setted "60" by default.
        [CacheRemoveAspect("IStudentService.Get")] // -> OK
        //[TransactionScopeAspect] -> OK
        //[PerformanceAspect(5)] -> OK
        //[LogAspect(typeof(FileLogger))] -> OK
        public IResult AddStudent(Student student)
        {
            var result = BusinessRules.Run(CheckIfStudentGenderInvalid(student.StudentGender), CheckIfStudentNameExists(student.StudentName));
            if (result != null)
            {
                return result;
            }
            _studentDal.Add(student);
            return new SuccessResult(StudentMessages.StudentAdded);
        }

        public IResult DeleteStudent(Student student)
        {
            // İş kodları
            _studentDal.Delete(student);
            return new SuccessResult();
        }

        public IDataResult<List<Student>> GetStudentByCourse(Guid id)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(s => s.CourseId == id));
        }

        public IResult UpdateStudent(Student student)
        {
            // İş kodları
            _studentDal.Update(student);
            return new SuccessResult();
        }

        public IResult CheckIfStudentNameExists(string name)
        {
            var result = _studentDal.GetAll(s => s.StudentName == name).Count;
            if (result > 0)
            {
                return new ErrorResult(StudentMessages.StudentNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfStudentGenderInvalid(int gender)
        {
            if (gender > 2)
            {
                return new ErrorResult(Constants.Messages.StudentMessages.StudentGenderInvalid);
            }
            return new SuccessResult();
        }
    }
}
