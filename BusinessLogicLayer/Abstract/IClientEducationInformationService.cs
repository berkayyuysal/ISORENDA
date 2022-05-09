using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IClientEducationInformationService
    {
        IResult Add(ClientEducationInformation clientEducationInformation);
        IResult Update(ClientEducationInformation clientEducationInformation);
        IResult Delete(ClientEducationInformation clientEducationInformation);
        IDataResult<List<ClientEducationInformation>> GetClientEducationInformations();
        IDataResult<ClientEducationInformation> GetClientEducationInformationById(Guid clientEducationInformationId);
    }
}
