using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetCities")]
        public IActionResult GetCities()
        {
            var result = _cityService.GetCities();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCityById")]
        public IActionResult GetCityById(Guid cityId)
        {
            var result = _cityService.GetCityById(cityId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
