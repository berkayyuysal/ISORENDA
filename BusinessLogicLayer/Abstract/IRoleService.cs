using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Abstract
{
    public interface IRoleService 
    {
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
        IDataResult<List<Role>> GetRoles();
        IDataResult<Role> GetRoleById(Guid roleId);
        IDataResult<List<Role>> GetRolesByUserId(Guid userId);
    }
}
