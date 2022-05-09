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
    public class CommentMentorController : Controller
    {
        ICommentMentorService _commentMentorService;
        public CommentMentorController(ICommentMentorService commentMentorService)
        {
            _commentMentorService = commentMentorService;
        }

        [HttpPost("AddCommentMentor")]
        public IActionResult AddCommentMentor(CommentMentor commentMentor)
        {
            var result = _commentMentorService.Add(commentMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateCommentMentor")]
        public IActionResult UpdateCommentMentor(CommentMentor commentMentor)
        {
            var result = _commentMentorService.Update(commentMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCommentMentor")]
        public IActionResult DeleteCommentMentor(CommentMentor commentMentor)
        {
            var result = _commentMentorService.Delete(commentMentor);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCommentMentors")]
        public IActionResult GetCommentMentors()
        {
            var result = _commentMentorService.GetCommentMentors();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCommentMentorById")]
        public IActionResult GetCommentMentorById(Guid commentMentorId)
        {
            var result = _commentMentorService.GetCommentMentorById(commentMentorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
