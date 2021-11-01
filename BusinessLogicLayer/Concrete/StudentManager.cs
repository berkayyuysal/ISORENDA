using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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

        public IDataResult<Student> GetStudentById(Student student)
        {
            // İş kodları
            return new SuccessDataResult<Student>(_studentDal.GetOne(s => s.StudentId == student.StudentId));
        }

        public IDataResult<List<Student>> GetAllStudents()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Student>>(Messages.MaintenanceTime);
            }
            // İş kodları
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(), Messages.StudentsListed);
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

        public IResult AddStudent(Student student)
        {
            // İş kodları
            if (student.StudentName.Length < 2)
            {
                return new ErrorResult(Messages.StudentNameInvalid);
            }
            _studentDal.Add(student);
            return new SuccessResult(Messages.StudentAdded);
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
    }
}
