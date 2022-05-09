using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IAuthenticateRoleService
    {
        IResult Add(AuthenticateRole authenticateRole);
        IResult Update(AuthenticateRole authenticateRole);
        IResult Delete(AuthenticateRole authenticateRole);
        IDataResult<List<AuthenticateRole>> GetAuthenticateRoles();
        IDataResult<AuthenticateRole> GetAuthenticateRoleById(Guid authenticateRoleId);
    }
}
