using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

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
            var result = _mentorService.Add(mentor, userForRegisterDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateMentor")]
        public IActionResult UpdateMentor(Mentor mentor)
        {
            var result = _mentorService.Update(mentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteMentor")]
        public IActionResult DeleteMentor(Mentor mentor)
        {
            var result = _mentorService.Delete(mentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
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
        public IActionResult GetMentorById(Guid mentorId)
        {
            var result = _mentorService.GetMentorById(mentorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetMentorByUserId")]
        public IActionResult GetMentorByUserId(Guid userId)
        {
            var result = _mentorService.GetMentorByUserId(userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetMentorsWithUserInformations")]
        public IActionResult GetMentorsWithUserInformations()
        {
            var result = _mentorService.GetMentorsWithUserInformations();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetOneMentorWithUserInformations")]
        public IActionResult GetOneMentorWithUserInformations(Guid mentorId)
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
