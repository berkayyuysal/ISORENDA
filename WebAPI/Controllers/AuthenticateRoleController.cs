using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateRoleController : Controller
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

        [HttpPost("UpdateAuthenticateRole")]
        public IActionResult UpdateAuthenticateRole(AuthenticateRole authenticateRole)
        {
            var result = _authenticateRoleService.Update(authenticateRole);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteAuthenticateRole")]
        public IActionResult DeleteAuthenticateRole(AuthenticateRole authenticateRole)
        {
            var result = _authenticateRoleService.Delete(authenticateRole);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAuthenticateRoles")]
        public IActionResult GetAuthenticateRoles()
        {
            var result = _authenticateRoleService.GetAuthenticateRoles();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAuthenticateRoleById")]
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
