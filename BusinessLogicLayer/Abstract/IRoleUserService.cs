using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IRoleUserService
    {
        IResult Add(RoleUser roleUser);
        IResult Update(RoleUser roleUser);
        IResult Delete(RoleUser roleUser);
        IDataResult<List<RoleUser>> GetRoleUsers();
        IDataResult<RoleUser> GetRoleUserById(Guid roleUserId);
    }
}
