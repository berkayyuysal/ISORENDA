using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TownController : Controller
    {
        ITownService _townService;
        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpGet("GetTowns")]
        public IActionResult GetTowns()
        {
            var result = _townService.GetTowns();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetTownById")]
        public IActionResult GetTownById(Guid townId)
        {
            var result = _townService.GetTownById(townId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetTownsByCityId")]
        public IActionResult GetTownsByCityId(Guid cityId)
        {
            var result = _townService.GetTownsByCityId(cityId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
