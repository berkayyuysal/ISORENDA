using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role,IsorendaContext>, IRoleDal
    {

    }
}
