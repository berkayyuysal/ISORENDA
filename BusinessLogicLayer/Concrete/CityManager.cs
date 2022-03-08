using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IDataResult<List<City>> GetCities()
        {
            var result = _cityDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<City>>(result);
            }
            return new ErrorDataResult<List<City>>();
        }

        public IDataResult<City> GetCityById(Guid cityId)
        {
            var result = _cityDal.GetById(cityId);
            if (result != null)
            {
                return new SuccessDataResult<City>(result);
            }
            return new ErrorDataResult<City>();
        }
    }
}
