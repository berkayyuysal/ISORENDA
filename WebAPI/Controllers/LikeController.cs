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
    public class LikeController : Controller
    {
        ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("AddLike")]
        public IActionResult AddLike(Like like)
        {
            try
            {
                var result = _likeService.Add(like);
                if (!result.IsSuccess)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("DeleteLike")]
        public IActionResult DeleteLike(Like like)
        {
            try
            {
                var result = _likeService.Delete(like);
                if (!result.IsSuccess)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetLikes")]
        public IActionResult GetLikes()
        {
            var result = _likeService.GetLikes();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetLikesByPostId")]
        public IActionResult GetLikesByPostId(Guid postId)
        {
            var result = _likeService.GetLikesByPostId(postId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetLikeById")]
        public IActionResult GetLikeById(Guid likeId)
        {
            var result = _likeService.GetLikeById(likeId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
