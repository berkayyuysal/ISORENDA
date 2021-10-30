using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
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

        public Student GetStudentById(Student student)
        {
            // İş kodları
            return _studentDal.GetOne(s=> s.StudentId == student.StudentId);
        }

        public List<Student> GetAllStudents()
        {
            // İş kodları
            return _studentDal.GetAll();
        }

        public bool AddStudent(Student student)
        {
            // İş kodları
            _studentDal.Add(student);
            return true;
        }

        public bool DeleteStudent(Student student)
        {
            // İş kodları
            _studentDal.Delete(student);
            return true;
        }

        public bool UpdateStudent(Student student)
        {
            // İş kodları
            _studentDal.Update(student);
            return true;
        }

        public List<Student> GetStudentsByNameAndGender(Student student)
        {
            return _studentDal.GetAll(s => s.StudentName == student.StudentName && s.StudentGender == student.StudentGender);
        }
    }
}
