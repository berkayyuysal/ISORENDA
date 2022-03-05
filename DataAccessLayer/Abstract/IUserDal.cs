using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public List<Role> GetClaims(User user);
    }
}