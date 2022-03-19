using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost("AddAuthenticate")]
        public IActionResult AddAuthenticate(Authenticate authenticate)
        {

            try
            {
                var result = _authenticateService.Add(authenticate);
                if (!result.IsSuccess)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (ValidationException validationException)
            {
                return BadRequest(validationException.Errors);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
        }

        [HttpPost("UpdateAuthenticate")]
        public IActionResult UpdateAuthenticate(Authenticate authenticate)
        {
            var result = _authenticateService.Update(authenticate);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteAuthenticate")]
        public IActionResult DeleteAuthenticate(Authenticate authenticate)
        {
            var result = _authenticateService.Delete(authenticate);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAllAuthenticates")]
        public IActionResult GetAllAuthenticates()
        {
            var result = _authenticateService.GetAuthenticates();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAuthenticateById")]
        public IActionResult GetAuthenticateById(Guid autehnticateId)
        {
            var result = _authenticateService.GetAuthenticateById(autehnticateId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAuthenticateByName")]
        public IActionResult GetAuthenticateByName(string name)
        {
            var result = _authenticateService.GetAuthenticateByName(name);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


    }
}
