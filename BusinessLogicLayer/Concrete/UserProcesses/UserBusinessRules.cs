using System;
using BusinessLogicLayer.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Concrete.UserProcesses
{
    public partial class UserManager
    {
        private IResult CheckIsUserMailExists(string email)
        {
            var result = _userDal.GetOne(u => u.Email == email);
            if (result != null)
            {
                return new ErrorResult(UserMessages.MailAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIsUserUsernameExists(string username)
        {
            var result = _userDal.GetOne(u => u.Username == username);
            if (result != null)
            {
                return new ErrorResult(UserMessages.UsernameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIsUserDeleted(User user)
        {
            var result = _userDal.GetOne(u => u.UserId == user.UserId);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(UserMessages.UserNotFound);
        }
    }
}
