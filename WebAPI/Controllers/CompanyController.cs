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
    public class CompanyController : Controller
    {
        ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany(Company company, UserForRegisterDto userForRegisterDto)
        {
            try
            {
                var result = _companyService.Add(company, userForRegisterDto);
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

        [HttpPost("UpdateCompany")]
        public IActionResult UpdateCompany(Company company)
        {
            try
            {
                var result = _companyService.Update(company);
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

        [HttpDelete("DeleteCompany")]
        public IActionResult DeleteCompany(Company company)
        {
            var result = _companyService.Delete(company);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            var result = _companyService.GetCompanies();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetAllActiveCompanies")]
        public IActionResult GetAllActiveCompanies()
        {
            var result = _companyService.GetActiveCompanies();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetCompanyById")]
        public IActionResult GetCompanyById(Guid companyId)
        {
            var result = _companyService.GetCompanyById(companyId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetActiveCompanyById")]
        public IActionResult GetActiveCompanyById(Guid companyId)
        {
            var result = _companyService.GetActiveCompanyById(companyId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
