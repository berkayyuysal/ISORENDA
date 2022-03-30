using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginLogController : Controller
    {
        ILoginLogService _loginLogService;

        public LoginLogController(ILoginLogService loginLogService)
        {
            _loginLogService = loginLogService;
        }

        [HttpPost("AddLoginLog")]
        public IActionResult AddLoginLog(LoginLog loginLog, Guid userId)
        {
            var result = _loginLogService.Add(loginLog, userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateForLogOutLoginLog")]
        public IActionResult UpdateForLogOutLoginLog(LoginLog loginLog)
        {
            var result = _loginLogService.UpdateForLogOut(loginLog);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetLoginLogs")]
        public IActionResult GetLoginLogs()
        {
            var result = _loginLogService.GetLoginLogs();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetLoginLogById")]
        public IActionResult GetLoginLogById(Guid loginLogId)
        {
            var result = _loginLogService.GetLoginLogById(loginLogId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetLoginLogsByUserId")]
        public IActionResult GetLoginLogsByUserId(Guid userId)
        {
            var result = _loginLogService.GetLoginLogsByUserId(userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
