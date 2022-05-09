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
    public class CommentPostController : Controller
    {
        ICommentPostService _commentPostService;
        public CommentPostController(ICommentPostService commentPostService)
        {
            _commentPostService = commentPostService;
        }

        [HttpPost("AddCommentPost")]
        public IActionResult AddCommentPost(CommentPost commentPost)
        {
            var result = _commentPostService.Add(commentPost);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateCommentPost")]
        public IActionResult UpdateCommentPost(CommentPost commentPost)
        {
            var result = _commentPostService.Update(commentPost);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCommentPost")]
        public IActionResult DeleteCommentPost(CommentPost commentPost)
        {
            var result = _commentPostService.Delete(commentPost);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCommentPosts")]
        public IActionResult GetCommentPosts()
        {
            var result = _commentPostService.GetCommentPosts();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCommentPostById")]
        public IActionResult GetCommentPostById(Guid commentPostId)
        {
            var result = _commentPostService.GetCommentPostById(commentPostId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
