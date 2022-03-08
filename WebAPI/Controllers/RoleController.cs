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

        [HttpPost("AddRole")]
        public IActionResult AddRole(Role role)
        {
            var result = _roleService.Add(role);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateRole")]
        public IActionResult UpdateRole(Role role)
        {
            var result = _roleService.Update(role);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteRole")]
        public IActionResult DeleteRole(Role role)
        {
            var result = _roleService.Delete(role);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var result = _roleService.GetRoles();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetRoleById")]
        public IActionResult GetRoleById(Guid roleId)
        {
            var result = _roleService.GetRoleById(roleId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetRolesByUserId")]
        public IActionResult GetRolesByUserId(Guid userId)
        {
            var result = _roleService.GetRolesByUserId(userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}