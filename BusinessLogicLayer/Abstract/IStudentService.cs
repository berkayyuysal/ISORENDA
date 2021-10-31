using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IStudentService
    {
        Student GetStudentById(Student student);
        List<Student> GetStudentsByNameAndGender(Student student);
        List<Student> GetAllStudents();
        bool AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        List<StudentDetailDto> GetStudentDetails();
    }
}
