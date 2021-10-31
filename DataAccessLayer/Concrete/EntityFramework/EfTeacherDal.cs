using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfTeacherDal: EfEntityRepositoryBase<Teacher, IsorendaContext>, ITeacherDal
    {
    }
}
