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
    public class AddressController : Controller
    {
        IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("AddAddress")]
        public ActionResult AddAddress(Address address, User user)
        {
            var result = _addressService.AddAddress(address, user);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("DeleteAddress")]
        public ActionResult DeleteAddress(Address address)
        {
            var result = _addressService.DeleteAddress(address);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("GetAddressByUserId")]
        public ActionResult GetAddressByUserId(Guid id)
        {
            var result = _addressService.GetAddressesByUserId(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("GetAddresses")]
        public ActionResult GetAddresses()
        {
            var result = _addressService.GetAddresses();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPost("UpdateAddresses")]
        public ActionResult UpdateAddress(Address address)
        {
            var result = _addressService.UpdateAddress(address);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


    }
}
