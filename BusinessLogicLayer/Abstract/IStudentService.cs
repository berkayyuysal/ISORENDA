using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IStudentService
    {
        IDataResult<Student> GetStudentById(Guid id);
        IDataResult<List<Student>> GetStudentsByNameAndGender(Student student);
        IDataResult<List<Student>> GetAllStudents();
        IDataResult<List<StudentDetailDto>> GetStudentDetails();
        IResult AddStudent(Student student);
        IResult UpdateStudent(Student student);
        IResult DeleteStudent(Student student);
    }
}
