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
    public class DiscountController : Controller
    {
        IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("AddDiscount")]
        public IActionResult AddDiscount(Discount discount)
        {
            var result = _discountService.Add(discount);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateDiscount")]
        public IActionResult UpdateDiscount(Discount discount)
        {
            var result = _discountService.Update(discount);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteDiscount")]
        public IActionResult DeleteDiscount(Discount discount)
        {
            var result = _discountService.Delete(discount);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetDiscounts")]
        public IActionResult GetDiscounts()
        {
            var result = _discountService.GetDiscounts();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetDiscountById")]
        public IActionResult GetDiscountById(Guid discountId)
        {
            var result = _discountService.GetDiscountById(discountId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
