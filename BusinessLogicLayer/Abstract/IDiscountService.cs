using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IDiscountService
    {
        IResult Add(Discount discount);
        IResult Update(Discount discount);
        IResult Delete(Discount discount);
        IDataResult<List<Discount>> GetDiscounts();
        IDataResult<Discount> GetDiscountById(Guid discountId);
    }
}
