using System;
using BusinessLogicLayer.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Concrete.MentorProcesses
{
    public partial class MentorManager
    {
        private IResult CheckIsIdentityNumberExists(string identityNumber)
        {
            var result = _mentorDal.GetOne(m => m.IdentityNumber == identityNumber);
            if (result != null)
            {
                return new ErrorResult("Bu T.C. Kimlik Numarası Kullanılmaktadır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIsMentorDeleted(Mentor mentor)
        {
            var userResult = _userService.GetUserById(mentor.UserId);
            if (!userResult.Data.Status)
            {
                return new ErrorResult(UserMessages.UserNotFound);
            }
            return new SuccessResult();
        }
    }
}
