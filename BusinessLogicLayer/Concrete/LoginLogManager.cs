using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class LoginLogManager : ILoginLogService
    {
        ILoginLogDal _loginLogDal;
        public LoginLogManager(ILoginLogDal loginLogDal)
        {
            _loginLogDal = loginLogDal;
        }

        public IResult Add(LoginLog loginLog, Guid userId)
        {
            loginLog.UserId = userId;
            _loginLogDal.Add(loginLog);
            return new SuccessResult();
        }

        public IResult Update(LoginLog loginLog)
        {
            _loginLogDal.Update(loginLog);
            return new SuccessResult();
        }

        public IDataResult<List<LoginLog>> GetLoginLogs()
        {
            var result = _loginLogDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<LoginLog>>(result);
            }
            return new ErrorDataResult<List<LoginLog>>();
        }

        public IDataResult<LoginLog> GetLoginLogById(Guid loginLogId)
        {
            var result = _loginLogDal.GetById(loginLogId);
            if (result != null)
            {
                return new SuccessDataResult<LoginLog>(result);
            }
            return new ErrorDataResult<LoginLog>();
        }
    }
}
