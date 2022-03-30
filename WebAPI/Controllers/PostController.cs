using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("AddPost")]
        public IActionResult AddPost(Post post, Guid mentorId)
        {
            var result = _postService.Add(post, mentorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("UpdatePost")]
        public IActionResult UpdatePost(Post post)
        {
            var result = _postService.Update(post);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeletePost")]
        public IActionResult DeletePost(Post post)
        {
            var result = _postService.Delete(post);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetPosts")]
        public IActionResult GetPosts()
        {
            var result = _postService.GetPosts();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetActivePosts")]
        public IActionResult GetActivePosts()
        {
            var result = _postService.GetActivePosts();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetPostById")]
        public IActionResult GetPostById(Guid postId)
        {
            var result = _postService.GetPostById(postId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetPostsByMentorId")]
        public IActionResult GetPostsByMentorId(Guid mentorId)
        {
            var result = _postService.GetPostsByMentorId(mentorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
