using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.TownProcesses
{
    public class TownManager : ITownService
    {
        ITownDal _townDal;
        public TownManager(ITownDal townDal)
        {
            _townDal = townDal;
        }

        [CacheAspect]
        public IDataResult<List<Town>> GetTowns()
        {
            var result = _townDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Town>>(result);
            }
            return new ErrorDataResult<List<Town>>();
        }

        public IDataResult<Town> GetTownById(Guid townId)
        {
            var result = _townDal.GetById(townId);
            if (result != null)
            {
                return new SuccessDataResult<Town>(result);
            }
            return new ErrorDataResult<Town>();
        }

        public IDataResult<List<Town>> GetTownsByCityId(Guid cityId)
        {
            var result = _townDal.GetAll(t => t.CityId == cityId);
            if (result != null)
            {
                return new SuccessDataResult<List<Town>>(result);
            }
            return new ErrorDataResult<List<Town>>();
        }
    }
}
