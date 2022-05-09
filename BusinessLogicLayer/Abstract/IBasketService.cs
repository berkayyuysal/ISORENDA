using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IBasketService
    {
        IResult Add(Basket basket);
        IResult Update(Basket basket);
        IResult Delete(Basket basket);
        IDataResult<List<Basket>> GetBaskets();
        IDataResult<Basket> GetBasketById(Guid basketId);
    }
}
