using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        public IResult Add(LoginLog loginLog, Guid userId)
        {
            loginLog.UserId = userId;
            loginLog.LoginDate = DateTime.Now;
            _loginLogDal.Add(loginLog);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        public IResult UpdateForLogOut(LoginLog loginLog)
        {
            loginLog.LogoutDate = DateTime.Now;
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

        public IDataResult<List<LoginLog>> GetLoginLogsByUserId(Guid userId)
        {
            var result = _loginLogDal.GetAll(l => l.UserId == userId);
            if (result != null)
            {
                return new SuccessDataResult<List<LoginLog>>(result);
            }
            return new ErrorDataResult<List<LoginLog>>(result);
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
