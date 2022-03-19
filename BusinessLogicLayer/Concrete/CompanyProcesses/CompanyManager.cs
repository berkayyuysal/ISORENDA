using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.DTOs;

namespace BusinessLogicLayer.Concrete.CompanyProcesses
{
    public partial class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        IUserService _userService;
        IAuthService _authService;
        public CompanyManager(ICompanyDal companyDal , IUserService userService, IAuthService authService)
        {
            _companyDal = companyDal;
            _userService = userService;
            _authService = authService;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("ICompanyService.Get")]
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company, UserForRegisterDto userForRegisterDto)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsTaxNumberExists(company.TaxNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var user = _authService.Register(userForRegisterDto);
            if (!user.IsSuccess)
            {
                return new ErrorResult(user.Message);
            }

            company.UserId = user.Data.UserId;
            company.User = user.Data;

            _companyDal.Add(company);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("ICompanyService.Get")]
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Update(Company company)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsTaxNumberExists(company.TaxNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var updatedUserResult = _userService.Update(company.User);
            if (!updatedUserResult.IsSuccess)
            {
                return new ErrorResult(updatedUserResult.Message);
            }

            _companyDal.Update(company);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("ICompanyService.Get")]
        public IResult Delete(Company company)
        {
            var userResult = _userService.GetActiveUserById(company.UserId);
            if (!userResult.IsSuccess)
            {
                return new ErrorResult(userResult.Message);
            }

            var deletedUserResult = _userService.Delete(userResult.Data);
            if (!deletedUserResult.IsSuccess)
            {
                return new ErrorResult(deletedUserResult.Message);
            }

            return new SuccessResult(company.Name + " adlı şirket silindi");
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

        public IDataResult<List<Company>> GetActiveCompanies()
        {
            var result = _companyDal.GetAll(c => c.User.Status == true);
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

        public IDataResult<Company> GetActiveCompanyById(Guid companyId)
        {
            var result = _companyDal.GetOne(c => c.User.Status == true && c.CompanyId == companyId);
            if (result != null)
            {
                return new SuccessDataResult<Company>(result);
            }
            return new ErrorDataResult<Company>();
        }
    }
}
