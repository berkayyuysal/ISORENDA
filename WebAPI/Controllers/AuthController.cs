using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Entities.DTOs;
using FluentValidation;

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
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                var userToLogin = _authService.Login(userForLoginDto);
                if (!userToLogin.IsSuccess)
                {
                    return BadRequest(userToLogin.Message);
                }

                var result = _authService.CreateAccessToken(userToLogin.Data);
                if (result.IsSuccess)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.Message);
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

        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            try
            {
                var registerResult = _authService.Register(userForRegisterDto);

                if (!registerResult.IsSuccess)
                {
                    return BadRequest(registerResult.Message);
                }

                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result.Message);
            }
            catch (ValidationException validationException)
            {
                return BadRequest(validationException);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
