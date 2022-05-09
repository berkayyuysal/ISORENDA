using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateRoleController : ControllerBase
    {
        IAuthenticateRoleService _authenticateRoleService;
        public AuthenticateRoleController(IAuthenticateRoleService authenticateRoleService)
        {
            _authenticateRoleService = authenticateRoleService;
        }

        [HttpPost("AddAuthenticateRole")]
        public IActionResult AddAuthenticateRole(AuthenticateRole authenticateRole)
        {
            var result = _authenticateRoleService.Add(authenticateRole);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("UpdateAuthenticate")]
        public IActionResult UpdateAuthenticateRole(AuthenticateRole authenticateRole)
        {
            var result = _authenticateRoleService.Update(authenticateRole);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteAuthenticate")]
        public IActionResult DeleteAuthenticateRole(AuthenticateRole authenticateRole)
        {
            var result = _authenticateRoleService.Delete(authenticateRole);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAllAuthenticates")]
        public IActionResult GetAuthenticateRoles()
        {
            var result = _authenticateRoleService.GetAuthenticateRoles();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAuthenticateById")]
        public IActionResult GetAuthenticateRoleById(Guid authenticateRoleId)
        {
            var result = _authenticateRoleService.GetAuthenticateRoleById(authenticateRoleId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
