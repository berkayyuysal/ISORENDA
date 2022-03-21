﻿using System;
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
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                var result = _categoryService.Add(category);
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
                return BadRequest(exception);
            }
        }

        [HttpPost("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                var result = _categoryService.Update(category);
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
                return BadRequest(exception);
            }
        }

        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(Category category)
        {
            try
            {
                var result = _categoryService.Delete(category);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetCategories();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(Guid categoryId)
        {
            var result = _categoryService.GetCategoryById(categoryId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCategoriesByParentId")]
        public IActionResult GetCategoriesByParentId(Guid categoryParentId)
        {
            var result = _categoryService.GetCategoriesByParentId(categoryParentId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
