using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, IsorendaContext>, IStudentDal
    {
        public List<StudentDetailDto> GetStudentDetails()
        {
            using (IsorendaContext context = new IsorendaContext ())
            {
                var result = from s in context.Students
                             join t in context.Teachers
                             on s.StudentGender equals t.TeacherGender
                             select new StudentDetailDto
                             {
                                 StudentId = s.StudentId,
                                 StudentName = s.StudentName,
                                 TeacherName = t.TeacherName,
                                 Gender = s.StudentGender
                             };
                return result.ToList();
            }
        }
    }
}
