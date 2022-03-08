using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class AuthenticateManager : IAuthenticateService
    {
        IAuthenticateDal _authenticateDal;

        public AuthenticateManager(IAuthenticateDal authenticateDal)
        {
            _authenticateDal = authenticateDal;
        }

        public IResult Add(Authenticate authenticate)
        {
            _authenticateDal.Add(authenticate);
            return new SuccessResult();
        }

        public IResult Update(Authenticate authenticate)
        {
            _authenticateDal.Update(authenticate);
            return new SuccessResult();
        }

        public IResult Delete(Authenticate authenticate)
        {
            authenticate.Status = false;
            _authenticateDal.Update(authenticate);
            return new SuccessResult();
        }

        public IDataResult<List<Authenticate>> GetAuthenticates()
        {
            var result = _authenticateDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Authenticate>>(result);
            }
            return new ErrorDataResult<List<Authenticate>>();
        }

        public IDataResult<Authenticate> GetAuthenticateById(Guid id)
        {
            var result = _authenticateDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<Authenticate>(result);
            }
            return new ErrorDataResult<Authenticate>();
        }

        public IDataResult<Authenticate> GetAuthenticateByName(string name)
        {
            var result = _authenticateDal.GetOne(a => a.Name == name);
            if (result != null)
            {
                return new SuccessDataResult<Authenticate>(result);
            }
            return new ErrorDataResult<Authenticate>();
        }
    }
}
