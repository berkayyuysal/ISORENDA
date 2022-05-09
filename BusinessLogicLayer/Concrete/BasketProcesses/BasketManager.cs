using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.BasketProcesses
{
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;
        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IBasketService.Get")]
        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);
            return new SuccessResult();
        }

        public IResult Update(Basket basket)
        {
            _basketDal.Update(basket);
            return new SuccessResult();
        }

        public IResult Delete(Basket basket)
        {
            _basketDal.Delete(basket);
            return new SuccessResult();
        }

        public IDataResult<List<Basket>> GetBaskets()
        {
            var result = _basketDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Basket>>(result);
            }
            return new ErrorDataResult<List<Basket>>(result);
        }

        public IDataResult<Basket> GetBasketById(Guid basketId)
        {
            var result = _basketDal.GetById(basketId);
            if (result != null)
            {
                return new SuccessDataResult<Basket>(result);
            }
            return new ErrorDataResult<Basket>(result);
        }
    }
}
