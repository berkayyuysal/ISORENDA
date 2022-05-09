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
    public class CategoryCourseController : Controller
    {
        ICategoryCourseService _categoryCourseService;
        public CategoryCourseController(ICategoryCourseService categoryCourseService)
        {
            _categoryCourseService = categoryCourseService;
        }

        [HttpPost("AddCategoryCourse")]
        public IActionResult AddCategoryCourse(CategoryCourse categoryCourse, Course course, List<Guid> categoryIds)
        {
            var result = _categoryCourseService.Add(categoryCourse, course, categoryIds);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("UpdateCategoryCourse")]
        public IActionResult UpdateCategoryCourse(CategoryCourse categoryCourse, List<Guid> categoryIds)
        {
            var result = _categoryCourseService.Update(categoryCourse, categoryIds);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCategoryCourse")]
        public IActionResult DeleteCategoryCourse(CategoryCourse categoryCourse)
        {
            var result = _categoryCourseService.Delete(categoryCourse);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetCategoryCourses")]
        public IActionResult GetCategoryCourses()
        {
            var result = _categoryCourseService.GetCategoryCourses();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetCategoryCourseById")]
        public IActionResult GetCategoryCourseById(Guid categoryCourseId)
        {
            var result = _categoryCourseService.GetCategoryCourseById(categoryCourseId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
