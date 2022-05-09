using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.OrderProcesses
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult();
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }

        public IResult Delete(Order order)
        {
            order.Status = 0; // 0: Silinmiş, 1: Aktif, 2: Pasif
            _orderDal.Update(order);
            return new SuccessResult();
        }

        public IDataResult<Order> GetOrderById(Guid orderId)
        {
            var result = _orderDal.GetById(orderId);
            if (result != null)
            {
                return new SuccessDataResult<Order>(result);
            }
            return new ErrorDataResult<Order>();
        }

        public IDataResult<List<Order>> GetOrders()
        {
            var result = _orderDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Order>>(result);
            }
            return new ErrorDataResult<List<Order>>();
        }
    }
}
