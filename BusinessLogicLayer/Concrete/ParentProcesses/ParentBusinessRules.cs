using System;
using BusinessLogicLayer.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Concrete.ParentProcesses
{
    public partial class ParentManager
    {
        private IResult CheckIsIdentityNumberExists(string identityNumber)
        {
            var result = _parentDal.GetOne(p => p.IdentityNumber == identityNumber);
            if (result != null)
            {
                return new ErrorResult("Bu T.C. Kimlik Numarası Kullanılmaktadır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIsParentDeleted(Parent parent)
        {
            var userResult = _userService.GetUserById(parent.UserId);
            if (!userResult.Data.Status)
            {
                return new ErrorResult(UserMessages.UserNotFound);
            }
            return new SuccessResult();
        }
    }
}
