using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfClientDal : EfEntityRepositoryBase<Client, IsorendaContext>, IClientDal
    {
        public EfClientDal()
        {
        }
    }
}
