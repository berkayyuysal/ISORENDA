using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.ClientEducationInformationProcesses
{
    public class ClientEducationInformationManager : IClientEducationInformationService
    {
        IClientEducationInformationDal _clientEducationInformationDal;
        public ClientEducationInformationManager(IClientEducationInformationDal clientEducationInformationDal)
        {
            _clientEducationInformationDal = clientEducationInformationDal;
        }

        public IResult Add(ClientEducationInformation clientEducationInformation)
        {
            _clientEducationInformationDal.Add(clientEducationInformation);
            return new SuccessResult();
        }

        public IResult Update(ClientEducationInformation clientEducationInformation)
        {
            _clientEducationInformationDal.Update(clientEducationInformation);
            return new SuccessResult();
        }

        public IResult Delete(ClientEducationInformation clientEducationInformation)
        {
            _clientEducationInformationDal.Delete(clientEducationInformation);
            return new SuccessResult();
        }

        public IDataResult<ClientEducationInformation> GetClientEducationInformationById(Guid clientEducationInformationId)
        {
            var result = _clientEducationInformationDal.GetById(clientEducationInformationId);
            if (result != null)
            {
                return new SuccessDataResult<ClientEducationInformation>(result);
            }
            return new SuccessDataResult<ClientEducationInformation>();
        }

        public IDataResult<List<ClientEducationInformation>> GetClientEducationInformations()
        {
            var result = _clientEducationInformationDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<ClientEducationInformation>>(result);
            }
            return new SuccessDataResult<List<ClientEducationInformation>>();
        }
    }
}
