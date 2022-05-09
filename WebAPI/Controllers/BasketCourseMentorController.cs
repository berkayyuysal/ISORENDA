using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BasketCourseMentorController : Controller
    {
        IBasketCourseMentorService _basketCourseMentorService;
        public BasketCourseMentorController(IBasketCourseMentorService basketCourseMentorService)
        {
            _basketCourseMentorService = basketCourseMentorService;
        }

        [HttpPost("AddBasketCourseMentor")]
        public IActionResult AddBasketCourseMentor(BasketCourseMentor basketCourseMentor)
        {
            var result = _basketCourseMentorService.Add(basketCourseMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("UpdateBasketCourseMentor")]
        public IActionResult UpdateBasketCourseMentor(BasketCourseMentor basketCourseMentor)
        {
            var result = _basketCourseMentorService.Update(basketCourseMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteBasketCourseMentor")]
        public IActionResult DeleteBasketCourseMentor(BasketCourseMentor basketCourseMentor)
        {
            var result = _basketCourseMentorService.Delete(basketCourseMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAllBasketCourseMentor")]
        public IActionResult GetAllBasketCourseMentor()
        {
            var result = _basketCourseMentorService.GetBasketCourseMentor();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetBasketCourseMentorById")]
        public IActionResult GetBasketCourseMentorById(Guid BasketCourseMentorId)
        {
            var result = _basketCourseMentorService.GetBasketCourseMentorById(BasketCourseMentorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
