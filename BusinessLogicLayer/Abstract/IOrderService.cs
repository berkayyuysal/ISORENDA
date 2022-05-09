using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);
        IDataResult<List<Order>> GetOrders();
        IDataResult<Order> GetOrderById(Guid orderId);
    }
}
