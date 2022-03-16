using System;
using BusinessLogicLayer.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Concrete.ClientProcesses
{
    public partial class ClientManager
    {
        private IResult CheckIsIdentityNumberExists(string identityNumber)
        {
            var result = _clientDal.GetOne(c => c.IdentityNumber == identityNumber);
            if (result != null)
            {
                return new ErrorResult("Bu T.C. Kimlik Numarası Kullanılmaktadır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIsClientDeleted(Client client)
        {
            var userResult = _userService.GetUserById(client.UserId);
            if (!userResult.Data.Status)
            {
                return new ErrorResult(UserMessages.UserNotFound);
            }
            return new SuccessResult();
        }
    }
}
