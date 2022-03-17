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
    public class FileController : Controller
    {
        IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("AddFile")]
        public IActionResult AddFile(File file)
        {
            try
            {
                var result = _fileService.Add(file);
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

        [HttpPost("UpdateFile")]
        public IActionResult UpdateFile(File file)
        {
            try
            {
                var result = _fileService.Update(file);
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

        [HttpDelete("DeleteFile")]
        public IActionResult DeleteFile(File file)
        {
            try
            {
                var result = _fileService.Delete(file);
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

        [HttpGet("GetFiles")]
        public IActionResult GetFiles()
        {
            var result = _fileService.GetFiles();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetFileById")]
        public IActionResult GetFileById(Guid fileId)
        {
            var result = _fileService.GetFileById(fileId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
