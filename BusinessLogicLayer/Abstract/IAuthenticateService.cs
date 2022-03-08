using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IAuthenticateService
    {
        IResult Add(Authenticate authenticate);
        IResult Update(Authenticate authenticate);
        IResult Delete(Authenticate authenticate);
        IDataResult<List<Authenticate>> GetAuthenticates();
        IDataResult<Authenticate> GetAuthenticateById(Guid id);
        IDataResult<Authenticate> GetAuthenticateByName(string name);
    }
}
