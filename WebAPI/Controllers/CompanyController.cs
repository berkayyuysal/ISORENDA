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
    public class CompanyController : Controller
    {
        ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany(Company company)
        {
            var result = _companyService.Add(company);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("UpdateCompany")]
        public IActionResult UpdateCompany(Company company)
        {
            var result = _companyService.Update(company);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
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
    }
}
