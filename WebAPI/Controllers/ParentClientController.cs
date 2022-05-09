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
    public class ParentClientController : Controller
    {
        IParentClientService _parentClientService;
        public ParentClientController(IParentClientService parentClientService)
        {
            _parentClientService = parentClientService;
        }

        [HttpPost("AddParentClient")]
        public IActionResult AddParentClient(ParentClient parentClient)
        {
            var result = _parentClientService.Add(parentClient);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateParentClient")]
        public IActionResult UpdateParentClient(ParentClient parentClient)
        {
            var result = _parentClientService.Update(parentClient);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteParentClient")]
        public IActionResult DeleteParentClient(ParentClient parentClient)
        {
            var result = _parentClientService.Delete(parentClient);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetParentClients")]
        public IActionResult GetParentClients()
        {
            var result = _parentClientService.GetParentClients();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetParentClientById")]
        public IActionResult GetParentClientById(Guid parentClientId)
        {
            var result = _parentClientService.GetParentClientById(parentClientId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
