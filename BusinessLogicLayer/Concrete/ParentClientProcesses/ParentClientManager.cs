using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.ParentClientProcesses
{
    public class ParentClientManager : IParentClientService
    {
        IParentClientDal _parentClientDal;
        public ParentClientManager(IParentClientDal parentClientDal)
        {
            _parentClientDal = parentClientDal;
        }

        public IResult Add(ParentClient parentClient)
        {
            _parentClientDal.Add(parentClient);
            return new SuccessResult();
        }

        public IResult Update(ParentClient parentClient)
        {
            _parentClientDal.Update(parentClient);
            return new SuccessResult();
        }

        public IResult Delete(ParentClient parentClient)
        {
            _parentClientDal.Delete(parentClient);
            return new SuccessResult();
        }

        public IDataResult<List<ParentClient>> GetParentClients()
        {
            var result = _parentClientDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<ParentClient>>(result);
            }
            return new ErrorDataResult<List<ParentClient>>();
        }

        public IDataResult<ParentClient> GetParentClientById(Guid parentClientId)
        {
            var result = _parentClientDal.GetById(parentClientId);
            if (result != null)
            {
                return new SuccessDataResult<ParentClient>(result);
            }
            return new ErrorDataResult<ParentClient>();
        }
    }
}
