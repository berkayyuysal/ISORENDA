using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            var result = _orderService.Add(order);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateOrder")]
        public IActionResult UpdateOrder(Order order)
        {
            var result = _orderService.Update(order);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(Order order)
        {
            var result = _orderService.Delete(order);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            var result = _orderService.GetOrders();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetOrderById")]
        public IActionResult GetOrderById(Guid orderId)
        {
            var result = _orderService.GetOrderById(orderId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
