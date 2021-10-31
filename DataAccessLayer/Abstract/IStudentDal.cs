using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IStudentDal: IEntityRepository<Student>
    {
        List<StudentDetailDto> GetStudentDetails();
    }
}
