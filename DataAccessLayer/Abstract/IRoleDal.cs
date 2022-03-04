using System;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IRoleDal : IEntityRepository<Role>
    {
    }
}