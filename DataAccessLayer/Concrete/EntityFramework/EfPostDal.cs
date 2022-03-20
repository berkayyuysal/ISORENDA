using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, IsorendaContext>, IPostDal
    {
        public EfPostDal()
        {
        }
    }
}
