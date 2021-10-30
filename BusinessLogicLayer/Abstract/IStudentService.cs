using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IStudentService
    {
        Student GetStudentById(Student student);
        List<Student> GetStudentsByFilter(Student student);
        List<Student> GetAllStudents();
        bool AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
    }
}
