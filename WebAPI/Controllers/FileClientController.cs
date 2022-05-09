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
    public class FileClientController : Controller
    {
        IFileClientService _fileClientService;
        public FileClientController(IFileClientService fileClientService)
        {
            _fileClientService = fileClientService;
        }

        [HttpPost("AddFileClient")]
        public IActionResult AddFileClient(FileClient fileClient)
        {
            var result = _fileClientService.Add(fileClient);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateFileClient")]
        public IActionResult UpdateFileClient(FileClient fileClient)
        {
            var result = _fileClientService.Update(fileClient);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteFileClient")]
        public IActionResult DeleteFileClient(FileClient fileClient)
        {
            var result = _fileClientService.Delete(fileClient);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetFileClients")]
        public IActionResult GetFileClients()
        {
            var result = _fileClientService.GetFileClients();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetFileClientById")]
        public IActionResult GetFileClientById(Guid fileClientById)
        {
            var result = _fileClientService.GetFileClientById(fileClientById);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
