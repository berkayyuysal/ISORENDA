using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, IsorendaContext>, ICategoryDal
    {
        public EfCategoryDal()
        {
        }
    }
}
