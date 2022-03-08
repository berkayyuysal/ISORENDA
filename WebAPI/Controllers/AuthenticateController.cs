﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
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
            var result = _authenticateService.Add(authenticate);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPost("UpdateAuthenticate")]
        public IActionResult UpdateAuthenticate(Authenticate authenticate)
        {
            var result = _authenticateService.Update(authenticate);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("DeleteAuthenticate")]
        public IActionResult DeleteAuthenticate(Authenticate authenticate)
        {
            var result = _authenticateService.Delete(authenticate);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("GetAllAuthenticates")]
        public IActionResult GetAllAuthenticates()
        {
            var result = _authenticateService.GetAuthenticates();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("GetAuthenticateById")]
        public IActionResult GetAuthenticateById(Guid id)
        {
            var result = _authenticateService.GetAuthenticateById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("GetAuthenticateByName")]
        public IActionResult GetAuthenticateByName(string name)
        {
            var result = _authenticateService.GetAuthenticateByName(name);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


    }
}
