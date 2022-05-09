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
    public class ClientEducationInformationController : Controller
    {
        IClientEducationInformationService _clientEducationInformationService;
        public ClientEducationInformationController(IClientEducationInformationService clientEducationInformationService)
        {
            _clientEducationInformationService = clientEducationInformationService;
        }

        [HttpPost("AddClientEducationInformation")]
        public IActionResult AddClientEducationInformation(ClientEducationInformation clientEducationInformation)
        {
            _clientEducationInformationService.Add(clientEducationInformation);
            return Ok();
        }

        [HttpPost("UpdateClientEducationInformation")]
        public IActionResult UpdateClientEducationInformation(ClientEducationInformation clientEducationInformation)
        {
            _clientEducationInformationService.Update(clientEducationInformation);
            return Ok();
        }

        [HttpDelete("DeleteClientEducationInformation")]
        public IActionResult DeleteClientEducationInformation(ClientEducationInformation clientEducationInformation)
        {
            _clientEducationInformationService.Delete(clientEducationInformation);
            return Ok();
        }

        [HttpGet("GetClientEducationInformations")]
        public IActionResult GetClientEducationInformations()
        {
            var result = _clientEducationInformationService.GetClientEducationInformations();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetClientEducationInformationById")]
        public IActionResult GetClientEducationInformationById(Guid clientEducationInformationId)
        {
            var result = _clientEducationInformationService.GetClientEducationInformationById(clientEducationInformationId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
