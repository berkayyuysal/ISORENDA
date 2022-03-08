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

        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult();
        }

        public IResult Update(Role role)
        {
            _roleDal.GetOne(r => r.RoleId == role.RoleId);
            return new SuccessResult();
        }

        public IResult Delete(Role role)
        {
            role.Status = false;
            _roleDal.Update(role);
            return new SuccessResult();
        }

        public IDataResult<List<Role>> GetRoles()
        {
            var result = _roleDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Role>>(result);
            }
            return new ErrorDataResult<List<Role>>();
        }

        public IDataResult<Role> GetRoleById(Guid roleId)
        {
            var result = _roleDal.GetById(roleId);
            if (result != null)
            {
                return new SuccessDataResult<Role>(result);
            }
            return new ErrorDataResult<Role>();
        }

        public IDataResult<List<Role>> GetRolesByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
