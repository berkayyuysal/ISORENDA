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
    public class CourseController : Controller
    {
        ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse(Course course)
        {
            var result = _courseService.Add(course);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateCourse")]
        public IActionResult UpdateCourse(Course course)
        {
            var result = _courseService.Update(course);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(Course course)
        {
            var result = _courseService.Delete(course);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCourses")]
        public IActionResult GetCourses()
        {
            var result = _courseService.GetCourses();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCourseById")]
        public IActionResult GetCourseById(Guid courseId)
        {
            var result = _courseService.GetCourseById(courseId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

    }
}
