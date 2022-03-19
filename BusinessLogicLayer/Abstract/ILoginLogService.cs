using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ILoginLogService
    {
        IResult Add(LoginLog loginLog, Guid userId);
        IResult UpdateForLogOut(LoginLog loginLog);
        IDataResult<List<LoginLog>> GetLoginLogs();
        IDataResult<List<LoginLog>> GetLoginLogsByUserId(Guid userId);
        IDataResult<LoginLog> GetLoginLogById(Guid loginLogId);

    }
}
