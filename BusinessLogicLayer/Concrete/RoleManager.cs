using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Abstract;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> GetRoles()
        {
            return _roleDal.GetAll();
        }
    }
}
