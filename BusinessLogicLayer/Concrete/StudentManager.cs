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

namespace BusinessLogicLayer.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public IDataResult<Student> GetStudentById(Guid id)
        {
            // İş kodları
            return new SuccessDataResult<Student>(_studentDal.GetOne(s => s.StudentId == id));
        }

        public IDataResult<List<Student>> GetAllStudents()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Student>>(ServerMessages.MaintenanceTime);
            }
            // İş kodları
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(), StudentMessages.StudentsListed);
        }

        public IDataResult<List<Student>> GetStudentsByNameAndGender(Student student)
        {
            return new SuccessDataResult<List<Student>>
                (_studentDal.GetAll(s => s.StudentName == student.StudentName && s.StudentGender == student.StudentGender));
        }

        public IDataResult<List<StudentDetailDto>> GetStudentDetails()
        {
            return new SuccessDataResult<List<StudentDetailDto>>(_studentDal.GetStudentDetails());
        }

        [ValidationAspect(typeof(StudentValidator))]
        public IResult AddStudent(Student student)
        {
            // İş kodları
            ValidationTool.Validate(new StudentValidator(), student);
            if (CheckIfStudentGenderInvalid(student.StudentGender).IsSuccess && CheckIfStudentNameExists(student.StudentName).IsSuccess)
            {
                _studentDal.Add(student);
                return new SuccessResult(StudentMessages.StudentAdded);
            }
            return new ErrorResult();
        }

        public IResult DeleteStudent(Student student)
        {
            // İş kodları
            _studentDal.Delete(student);
            return new SuccessResult();
        }

        public IResult UpdateStudent(Student student)
        {
            // İş kodları
            _studentDal.Update(student);
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

        private IResult CheckIfStudentNameExists(string name)
        {
            var result = _studentDal.GetAll(s => s.StudentName == name).Count;
            if (result > 0)
            {
                return new ErrorResult(StudentMessages.StudentNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
