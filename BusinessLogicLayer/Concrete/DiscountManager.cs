using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        IDiscountDal _discountDal;
        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public IResult Add(Discount discount)
        {
            _discountDal.Add(discount);
            return new SuccessResult();
        }

        public IResult Update(Discount discount)
        {
            _discountDal.Update(discount);
            return new SuccessResult();
        }

        public IResult Delete(Discount discount)
        {
            discount.Status = false;
            _discountDal.Update(discount);
            return new SuccessResult();
        }

        public IDataResult<List<Discount>> GetDiscounts()
        {
            var result = _discountDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Discount>>(result);
            }
            return new ErrorDataResult<List<Discount>>();
        }

        public IDataResult<Discount> GetDiscountById(Guid discountId)
        {
            var result = _discountDal.GetById(discountId);
            if (result != null)
            {
                return new SuccessDataResult<Discount>(result);
            }
            return new ErrorDataResult<Discount>();
        }
    }
}
