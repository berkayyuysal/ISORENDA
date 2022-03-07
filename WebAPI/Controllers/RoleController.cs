using System;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var result = _roleService.GetRoles();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("AddRole")]
        public IActionResult AddRole(Role role)
        {
            var result = _roleService.AddRole(role);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteRole")]
        public IActionResult DeleteRole(Role role)
        {
            var result = _roleService.DeleteRole(role);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("UpdateRole")]
        public IActionResult UpdateRole(Role role)
        {
            var result = _roleService.UpdateRole(role);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetRoleById")]
        public IActionResult GetRoleById(Guid roleId)
        {
            var result = _roleService.GetRoleById(roleId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}