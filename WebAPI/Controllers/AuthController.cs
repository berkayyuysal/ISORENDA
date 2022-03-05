using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            // var userToLogin = _authService.Login(userForLoginDto);
            // if (!userToLogin.IsSuccess)
            // {
            //     return BadRequest(userToLogin.Message);
            // }

            // var result = _authService.CreateAccessToken(userToLogin.Data);
            // if (result.IsSuccess)
            // {
            //     return Ok(result.Data);
            // }

            // return BadRequest(result.Message);

            return BadRequest();
        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            // var userExists = _authService.UserExists(userForRegisterDto.Email);
            // if (!userExists.IsSuccess)
            // {
            //     return BadRequest(userExists.Message);
            // }

            // var registerResult = _authService.Register(userForRegisterDto);
            // var result = _authService.CreateAccessToken(registerResult.Data);
            // if (result.IsSuccess)
            // {
            //     return Ok(result.Data);
            // }

            // return BadRequest(result.Message);

            return BadRequest();
        }
    }
}
