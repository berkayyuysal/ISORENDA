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
    public class RoleUserController : Controller
    {
        IRoleUserService _roleUserService;
        public RoleUserController(IRoleUserService roleUserService)
        {
            _roleUserService = roleUserService;
        }

        [HttpPost("AddRoleUser")]
        public IActionResult AddRoleUser(RoleUser roleUser)
        {
            var result = _roleUserService.Add(roleUser);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateRoleUser")]
        public IActionResult UpdateRoleUser(RoleUser roleUser)
        {
            var result = _roleUserService.Update(roleUser);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteRoleUser")]
        public IActionResult DeleteRoleUser(RoleUser roleUser)
        {
            var result = _roleUserService.Delete(roleUser);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetRoleUsers")]
        public IActionResult GetRoleUsers()
        {
            var result = _roleUserService.GetRoleUsers();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetRoleUserById")]
        public IActionResult GetRoleUserById(Guid roleUserId)
        {
            var result = _roleUserService.GetRoleUserById(roleUserId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
