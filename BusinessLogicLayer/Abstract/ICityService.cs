using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetCities();
        IDataResult<City> GetCityById(Guid cityId);
    }
}
