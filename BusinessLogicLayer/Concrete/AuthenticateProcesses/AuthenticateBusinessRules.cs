using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;

namespace BusinessLogicLayer.Concrete.AuthenticateProcesses
{
    public partial class AuthenticateManager
    {
        private IResult CheckIsNameExists(Authenticate authenticate)
        {
            var authenticateResult = _authenticateDal.GetOne(a => a.Name.ToLower() == authenticate.Name.ToLower());
            if (authenticateResult != null)
            {
                return new ErrorResult("Böyle bir Authenticate bulunmaktadır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIsAuthenticateChanged(Authenticate authenticate)
        {
            var oldAuthenticate = _authenticateDal.GetById(authenticate.AuthenticateId);
            if (oldAuthenticate.Description != authenticate.Description || oldAuthenticate.Name != authenticate.Name)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Hey Developer! Update butonunu inaktif olarak ayarlamayı unuttun.");
        }

        private IResult CheckIsAuthenticateDeleted(Authenticate authenticate)
        {
            var authenticateResult = _authenticateDal.GetOne(a => a.AuthenticateId == authenticate.AuthenticateId);
            if (!authenticateResult.Status)
            {
                return new ErrorResult("Böyle bir Authenticate bulunamamaktadır.");
            }
            return new SuccessResult();
        }
    }
}
