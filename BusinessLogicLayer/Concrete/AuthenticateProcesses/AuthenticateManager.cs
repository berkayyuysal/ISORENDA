using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.AuthenticateProcesses
{
    public partial class AuthenticateManager : IAuthenticateService
    {
        IAuthenticateDal _authenticateDal;

        public AuthenticateManager(IAuthenticateDal authenticateDal)
        {
            _authenticateDal = authenticateDal;
        }

        [PerformanceAspect(20)]
        [SecuredOperation("superadmin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateService.Get")]
        [ValidationAspect(typeof(AuthenticateValidator))]
        public IResult Add(Authenticate authenticate)
        {
            var businessRuleResult = BusinessRules.Run(CheckIsNameExists(authenticate));
            if (businessRuleResult != null && authenticate.Status == false)
            {
                authenticate.Status = true;
                _authenticateDal.Update(authenticate);
                return new SuccessResult(authenticate.Name + " yetkisi Eklendi");
            }
            if (businessRuleResult == null)
            {
                _authenticateDal.Add(authenticate);
                return new SuccessResult(authenticate.Name + " yetkisi Eklendi");
            }

            return new ErrorResult(businessRuleResult.Message);
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateService.Get")]
        [ValidationAspect(typeof(AuthenticateValidator))]
        public IResult Update(Authenticate authenticate)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsAuthenticateChanged(authenticate));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }
            _authenticateDal.Update(authenticate);
            return new SuccessResult(authenticate.Name + " yetkisi güncellendi.");
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateService.Get")]
        public IResult Delete(Authenticate authenticate)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsAuthenticateDeleted(authenticate));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }
            authenticate.Status = false;
            _authenticateDal.Update(authenticate);
            return new SuccessResult(authenticate.Name + " yetkisi silindi.");
        }

        public IDataResult<List<Authenticate>> GetAuthenticates()
        {
            var result = _authenticateDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Authenticate>>(result);
            }
            return new ErrorDataResult<List<Authenticate>>(result);
        }

        public IDataResult<Authenticate> GetAuthenticateById(Guid authenticateId)
        {
            var result = _authenticateDal.GetById(authenticateId);
            if (result != null)
            {
                return new SuccessDataResult<Authenticate>(result);
            }
            return new ErrorDataResult<Authenticate>(result);
        }
    }
}
