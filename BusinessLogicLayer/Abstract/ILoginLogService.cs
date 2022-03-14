using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ILoginLogService
    {
        IResult Add(LoginLog loginLog, Guid userId);
        IResult Update(LoginLog loginLog);
        IDataResult<List<LoginLog>> GetLoginLogs();
        IDataResult<LoginLog> GetLoginLogById(Guid loginLogId);
    }
}
