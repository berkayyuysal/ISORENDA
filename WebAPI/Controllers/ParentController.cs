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
    public class ParentController : Controller
    {
        IParentService _parentService;
        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpPost("AddParent")]
        public IActionResult AddParent(Parent parent, UserForRegisterDto userForRegisterDto)
        {
            try
            {
                var result = _parentService.Add(parent, userForRegisterDto);
                if (!result.IsSuccess)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (ValidationException validationException)
            {
                return BadRequest(validationException.Errors);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("Updateparent")]
        public IActionResult UpdateParent(Parent parent)
        {
            try
            {
                var result = _parentService.Update(parent);
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
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("Deleteparent")]
        public IActionResult DeleteParent(Parent parent)
        {
            try
            {
                var result = _parentService.Delete(parent);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("Getparents")]
        public IActionResult GetParents()
        {
            var result = _parentService.GetParents();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetparentById")]
        public IActionResult GetParentById(Guid parentId)
        {
            var result = _parentService.GetParentById(parentId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetparentByUserId")]
        public IActionResult GetParentByUserId(Guid userId)
        {
            var result = _parentService.GetParentByUserId(userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetparentsWithUserInformations")]
        public IActionResult GetParentsWithUserInformations()
        {
            var result = _parentService.GetParentsWithUserInformations();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetOneparentWithUserInformations")]
        public IActionResult GetOneParentWithUserInformations(Guid parentId)
        {
            var result = _parentService.GetOneParentWithUserInformations(parentId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
