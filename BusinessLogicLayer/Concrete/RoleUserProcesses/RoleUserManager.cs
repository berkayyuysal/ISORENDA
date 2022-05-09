using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.RoleUserProcesses
{
    public class RoleUserManager : IRoleUserService
    {
        IRoleUserDal _roleUserDal;
        public RoleUserManager(IRoleUserDal roleUserDal)
        {
            _roleUserDal = roleUserDal;
        }

        public IResult Add(RoleUser roleUser)
        {
            _roleUserDal.Add(roleUser);
            return new SuccessResult();
        }

        public IResult Update(RoleUser roleUser)
        {
            _roleUserDal.Update(roleUser);
            return new SuccessResult();
        }

        public IResult Delete(RoleUser roleUser)
        {
            _roleUserDal.Delete(roleUser);
            return new SuccessResult();
        }

        public IDataResult<RoleUser> GetRoleUserById(Guid roleUserId)
        {
            var result = _roleUserDal.GetById(roleUserId);
            if (result != null)
            {
                return new SuccessDataResult<RoleUser>(result);
            }
            return new ErrorDataResult<RoleUser>();
        }

        public IDataResult<List<RoleUser>> GetRoleUsers()
        {
            var result = _roleUserDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<RoleUser>>(result);
            }
            return new ErrorDataResult<List<RoleUser>>();
        }
    }
}
