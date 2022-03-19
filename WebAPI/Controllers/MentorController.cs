using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MentorController : Controller
    {
        IMentorService _mentorService;
        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpPost("AddMentor")]
        public IActionResult AddMentor(Mentor mentor, UserForRegisterDto userForRegisterDto)
        {
            try
            {
                var result = _mentorService.Add(mentor, userForRegisterDto);
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

        [HttpPost("UpdateMentor")]
        public IActionResult UpdateMentor(Mentor mentor)
        {
            try
            {
                var result = _mentorService.Update(mentor);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
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

        [HttpDelete("DeleteMentor")]
        public IActionResult DeleteMentor(Mentor mentor)
        {
            try
            {
                var result = _mentorService.Delete(mentor);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetMentors")]
        public IActionResult GetMentors()
        {
            var result = _mentorService.GetMentors();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetMentorById")]
        public IActionResult GetClientById(Guid mentorId)
        {
            var result = _mentorService.GetMentorById(mentorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetMentorByUserId")]
        public IActionResult GetClientByUserId(Guid userId)
        {
            var result = _mentorService.GetMentorByUserId(userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetMentorsWithUserInformations")]
        public IActionResult GetClientsWithUserInformations()
        {
            var result = _mentorService.GetMentorsWithUserInformations();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetOneMentorWithUserInformations")]
        public IActionResult GetOneClientWithUserInformations(Guid mentorId)
        {
            var result = _mentorService.GetOneMentorWithUserInformations(mentorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
