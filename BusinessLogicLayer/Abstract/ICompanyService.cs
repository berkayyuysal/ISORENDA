using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface ICompanyService
    {
        IResult Add(Company company);
        IResult Update(Company company);
        IResult Delete(Company company);
        IDataResult<List<Company>> GetCompanies();
        IDataResult<Company> GetCompanyById(Guid companyId);
    }
}
