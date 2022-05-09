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
    public class BasketController : Controller
    {
        IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("AddBasket")]
        public IActionResult AddBasket(Basket basket)
        {
            var result = _basketService.Add(basket);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateBasket")]
        public IActionResult UpdateBasket(Basket basket)
        {
            var result = _basketService.Update(basket);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteBasket")]
        public IActionResult DeleteBasket(Basket basket)
        {
            var result = _basketService.Delete(basket);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetBaskets")]
        public IActionResult GetBaskets()
        {
            var result = _basketService.GetBaskets();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetBasketById")]
        public IActionResult GetBasketById(Guid basketId)
        {
            var result = _basketService.GetBasketById(basketId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
