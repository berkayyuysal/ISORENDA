using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete.AuthenticateRoleProcesses
{
    public partial class AuthenticateRoleManager
    {
        private IResult CheckIsAuthenticateRoleExists(AuthenticateRole authenticateRole)
        {
            var authenticateRoleResult = _authenticateRoleDal.GetOne(a => a.AuthenticateRoleId == authenticateRole.AuthenticateRoleId);
            if (authenticateRoleResult != null)
            {
                return new ErrorResult("Böyle bir AuthenticateRole bulunmaktadır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIsAuthenticateRoleChanged(AuthenticateRole authenticateRole)
        {
            var oldAuthenticateRole = _authenticateRoleDal.GetById(authenticateRole.AuthenticateRoleId);
            if (oldAuthenticateRole.AuthenticateId != authenticateRole.AuthenticateId || oldAuthenticateRole.RoleId != authenticateRole.RoleId)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Hey Developer! Update butonunu inaktif olarak ayarlamayı unuttun.");
        }

    }
}
