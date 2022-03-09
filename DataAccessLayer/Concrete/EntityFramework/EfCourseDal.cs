using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, IsorendaContext>, ICourseDal
    {
        public EfCourseDal()
        {
        }
    }
}
