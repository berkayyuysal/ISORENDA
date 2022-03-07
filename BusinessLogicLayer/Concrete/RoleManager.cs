using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Abstract;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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

        public IResult AddRole(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult();
        }

        public IResult DeleteRole(Role role)
        {
            role.Status = false;
            _roleDal.Update(role);
            return new SuccessResult();
        }

        public IDataResult<Role> GetRoleById(Guid roleId)
        {
            return new SuccessDataResult<Role>(_roleDal.GetById(roleId));
        }

        public IDataResult<List<Role>> GetRoles()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll(), "Roller geldi.");
        }

        public IDataResult<List<Role>> GetRolesByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateRole(Role role)
        {
            _roleDal.GetOne(r => r.RoleId == role.RoleId);
            return new SuccessResult();
        }
    }
}
