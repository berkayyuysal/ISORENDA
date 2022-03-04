using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Abstract
{
    public interface IRoleService 
    {
        public List<Role> GetRoles();
    }
}
