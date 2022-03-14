using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        IUserService _userService;
        public CompanyManager(ICompanyDal companyDal , IUserService userService)
        {
            _companyDal = companyDal;
            _userService = userService;
        }

        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult();
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult();
        }

        public IResult Delete(Company company)
        {
            var takenCompany = _companyDal.GetById(company.CompanyId);
            var user = _userService.GetUserById(takenCompany.UserId);
            user.Data.Status = false;
            _userService.Delete(user.Data);
            return new SuccessResult(takenCompany.Name + " adlı " + "kullanıcı silindi");
        }

        public IDataResult<List<Company>> GetCompanies()
        {
            var result = _companyDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Company>>(result);
            }
            return new ErrorDataResult<List<Company>>();
        }

        public IDataResult<Company> GetCompanyById(Guid companyId)
        {
            var result = _companyDal.GetById(companyId);
            if (result != null)
            {
                return new SuccessDataResult<Company>(result);
            }
            return new ErrorDataResult<Company>();
        }

        
    }
}
