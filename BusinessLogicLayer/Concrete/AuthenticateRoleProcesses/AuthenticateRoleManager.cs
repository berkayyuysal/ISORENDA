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

namespace BusinessLogicLayer.Concrete.AuthenticateRoleProcesses
{
    public partial class AuthenticateRoleManager : IAuthenticateRoleService
    {
        IAuthenticateRoleDal _authenticateRoleDal;
        public AuthenticateRoleManager(IAuthenticateRoleDal authenticateRoleDal)
        {
            _authenticateRoleDal = authenticateRoleDal;
        }

        [PerformanceAspect(20)]
        [SecuredOperation("superadmin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateRoleService.Get")]
        [ValidationAspect(typeof(AuthenticateRoleValidator))]
        public IResult Add(AuthenticateRole authenticateRole)
        {
            var businessRuleResult = BusinessRules.Run(CheckIsAuthenticateRoleExists(authenticateRole));
            if (businessRuleResult != null)
            {
                _authenticateRoleDal.Add(authenticateRole);
                return new SuccessResult();
            }
            return new ErrorResult(businessRuleResult.Message);
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateRoleService.Get")]
        [ValidationAspect(typeof(AuthenticateRoleValidator))]
        public IResult Update(AuthenticateRole authenticateRole)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsAuthenticateRoleChanged(authenticateRole));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }
            _authenticateRoleDal.Update(authenticateRole);
            return new SuccessResult();
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateRoleService.Get")]
        public IResult Delete(AuthenticateRole authenticateRole)
        {
            _authenticateRoleDal.Delete(authenticateRole);
            return new SuccessResult();
        }

        public IDataResult<AuthenticateRole> GetAuthenticateRoleById(Guid authenticateRoleId)
        {
            var result = _authenticateRoleDal.GetById(authenticateRoleId);
            if (result != null)
            {
                return new SuccessDataResult<AuthenticateRole>(result);
            }
            return new ErrorDataResult<AuthenticateRole>(result);
        }

        public IDataResult<List<AuthenticateRole>> GetAuthenticateRoles()
        {
            var result = _authenticateRoleDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<AuthenticateRole>>(result);
            }
            return new ErrorDataResult<List<AuthenticateRole>>(result);
        }
    }
}
