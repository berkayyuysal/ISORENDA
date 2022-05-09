using System;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FileMentorController : Controller
    {
        IFileMentorService _fileMentorService;
        public FileMentorController(IFileMentorService fileMentorService)
        {
            _fileMentorService = fileMentorService;
        }

        [HttpPost("AddFileMentor")]
        public IActionResult AddFileMentor(FileMentor fileMentor)
        {
            var result = _fileMentorService.Add(fileMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateFileMentor")]
        public IActionResult UpdateFileMentor(FileMentor fileMentor)
        {
            var result = _fileMentorService.Update(fileMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteFileMentor")]
        public IActionResult DeleteFileMentor(FileMentor fileMentor)
        {
            var result = _fileMentorService.Delete(fileMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetFileMentors")]
        public IActionResult GetFileMentors()
        {
            var result = _fileMentorService.GetFileMentors();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetFileMentorById")]
        public IActionResult GetFileMentorById(Guid fileMentorById)
        {
            var result = _fileMentorService.GetFileMentorById(fileMentorById);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
