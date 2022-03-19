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

namespace BusinessLogicLayer.Concrete.ParentProcesses
{
    public partial class ParentManager : IParentService
    {
        IParentDal _parentDal;
        IUserService _userService;
        IAuthService _authService;
        public ParentManager(IParentDal parentDal, IUserService userService, IAuthService authService)
        {
            _parentDal = parentDal;
            _userService = userService;
            _authService = authService;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IParentService.Get")]
        [ValidationAspect(typeof(ParentValidator))]
        public IResult Add(Parent parent, UserForRegisterDto userForRegisterDto)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsIdentityNumberExists(parent.IdentityNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var user = _authService.Register(userForRegisterDto);
            if (!user.IsSuccess)
            {
                return new ErrorResult(user.Message);
            }

            parent.UserId = user.Data.UserId;
            parent.User = user.Data;

            _parentDal.Add(parent);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IParentService.Get")]
        [ValidationAspect(typeof(ParentValidator))]
        public IResult Update(Parent parent)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsIdentityNumberExists(parent.IdentityNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var updatedUserResult = _userService.Update(parent.User);
            if (!updatedUserResult.IsSuccess)
            {
                return new ErrorResult(updatedUserResult.Message);
            }
            _parentDal.Update(parent);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IParentService.Get")]
        public IResult Delete(Parent parent)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsParentDeleted(parent));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var userResult = _userService.GetUserById(parent.UserId);
            if (!userResult.IsSuccess)
            {
                return new ErrorResult(userResult.Message);
            }

            var deletedUserResult = _userService.Delete(userResult.Data);
            if (!deletedUserResult.IsSuccess)
            {
                return new ErrorResult(deletedUserResult.Message);
            }

            return new SuccessResult(parent.FirstName + " adlı kullanıcı silindi");
        }

        public IDataResult<List<Parent>> GetParents()
        {
            var result = _parentDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Parent>>(result);
            }
            return new ErrorDataResult<List<Parent>>();
        }

        public IDataResult<Parent> GetParentById(Guid parentId)
        {
            var result = _parentDal.GetById(parentId);
            if (result != null)
            {
                return new SuccessDataResult<Parent>(result);
            }
            return new ErrorDataResult<Parent>();
        }

        public IDataResult<Parent> GetParentByUserId(Guid userId)
        {
            var user = _userService.GetUserById(userId).Data;
            var result = _parentDal.GetOne(u => u.UserId == user.UserId);
            if (result != null)
            {
                return new SuccessDataResult<Parent>(result);
            }
            return new ErrorDataResult<Parent>();
        }

        public IDataResult<List<Parent>> GetParentsWithUserInformations()
        {
            var result = _parentDal.GetParentsWithUserInformation();
            if (result != null)
            {
                return new SuccessDataResult<List<Parent>>(result);
            }
            return new ErrorDataResult<List<Parent>>();
        }

        public IDataResult<Parent> GetOneParentWithUserInformations(Guid parentId)
        {
            var result = _parentDal.GetOneParentWithUserInformations(parentId);
            if (result != null)
            {
                return new SuccessDataResult<Parent>(result);
            }
            return new ErrorDataResult<Parent>();
        }
    }
}
