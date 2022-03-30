using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("AddClient")]
        [TransactionScopeAspect]
        public IActionResult AddClient(Client client, UserForRegisterDto userForRegisterDto)
        {
            var result = _clientService.Add(client, userForRegisterDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateClient")]
        public IActionResult UpdateClient(Client client)
        {
            var result = _clientService.Update(client);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteClient")]
        public IActionResult DeleteClient(Client client)
        {
            var result = _clientService.Delete(client);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {
            var result = _clientService.GetClients();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetClientById")]
        public IActionResult GetClientById(Guid clientId)
        {
            var result = _clientService.GetClientById(clientId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetClientByUserId")]
        public IActionResult GetClientByUserId(Guid userId)
        {
            var result = _clientService.GetClientByUserId(userId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetClientsWithUserInformations")]
        public IActionResult GetClientsWithUserInformations()
        {
            var result = _clientService.GetClientsWithUserInformations();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetOneClientWithUserInformations")]
        public IActionResult GetOneClientWithUserInformations(Guid clientId)
        {
            var result = _clientService.GetOneClientWithUserInformations(clientId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
