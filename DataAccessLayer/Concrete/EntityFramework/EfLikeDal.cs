using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfLikeDal : EfEntityRepositoryBase<Like, IsorendaContext>, ILikeDal
    {
        public EfLikeDal()
        {
        }
    }
}
