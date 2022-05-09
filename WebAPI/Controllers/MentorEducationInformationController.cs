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
    public class MentorEducationInformationController : Controller
    {
        IMentorEducationInformationService _mentorEducationInformationService;
        public MentorEducationInformationController(IMentorEducationInformationService mentorEducationInformationService)
        {
            _mentorEducationInformationService = mentorEducationInformationService;
        }

        [HttpPost("AddMentorEducationInformation")]
        public IActionResult AddClientEducationInformation(MentorEducationInformation mentorEducationInformation)
        {
            var result = _mentorEducationInformationService.Add(mentorEducationInformation);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateMentorEducationInformation")]
        public IActionResult UpdateMentorEducationInformation(MentorEducationInformation mentorEducationInformation)
        {
            var result = _mentorEducationInformationService.Update(mentorEducationInformation);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteMentorEducationInformation")]
        public IActionResult DeleteMentorEducationInformation(MentorEducationInformation mentorEducationInformation)
        {
            var result = _mentorEducationInformationService.Delete(mentorEducationInformation);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetMentorEducationInformations")]
        public IActionResult GetMentorEducationInformations()
        {
            var result = _mentorEducationInformationService.GetMentorEducationInformations();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetMentorEducationInformationById")]
        public IActionResult GetMentorEducationInformationById(Guid mentorEducationInformationId)
        {
            var result = _mentorEducationInformationService.GetMentorEducationInformationById(mentorEducationInformationId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
