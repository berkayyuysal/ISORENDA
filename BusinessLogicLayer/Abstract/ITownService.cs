using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ITownService
    {
        IDataResult<Town> GetTownById(Guid townId);
        IDataResult<List<Town>> GetTowns();
        IDataResult<List<Town>> GetTownsByCityId(Guid cityId);
    }
}
