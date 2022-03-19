using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface ICompanyService
    {
        IResult Add(Company company, UserForRegisterDto userForRegisterDto);
        IResult Update(Company company);
        IResult Delete(Company company);
        IDataResult<List<Company>> GetCompanies();
        IDataResult<List<Company>> GetActiveCompanies();
        IDataResult<Company> GetCompanyById(Guid companyId);
        IDataResult<Company> GetActiveCompanyById(Guid companyId);
    }
}
