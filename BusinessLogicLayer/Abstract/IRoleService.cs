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
        public IDataResult<List<Role>> GetRoles();
        public IResult AddRole(Role role);
        public IResult DeleteRole(Role role);
        public IResult UpdateRole(Role role);
        public IDataResult<List<Role>> GetRolesByUserId(Guid userId);
        public IDataResult<Role> GetRoleById(Guid roleId);
    }
}
