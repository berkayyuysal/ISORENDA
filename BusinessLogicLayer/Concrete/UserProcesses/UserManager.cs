using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants.Messages;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.UserProcesses
{
    public partial class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IUserService.Get")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            var result = BusinessRules.Run(CheckIsUserMailExists(user.Email), CheckIsUserUsernameExists(user.Username));
            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IUserService.Get")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsUserMailExists(user.Email), CheckIsUserUsernameExists(user.Username));
            if (businessRuleResults != null)
            {
                new ErrorResult(businessRuleResults.Message);
            }

            _userDal.Update(user);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsUserDeleted(user));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }
            user.Status = false;
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetUsers()
        {
            var result = _userDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<User>>(result);
            }
            return new ErrorDataResult<List<User>>();
        }

        public IDataResult<List<User>> GetActiveUsers()
        {
            var result = _userDal.GetAll(u => u.Status == true);
            if (result != null)
            {
                return new SuccessDataResult<List<User>>(result);
            }
            return new ErrorDataResult<List<User>>();
        }

        public IDataResult<User> GetUserById(Guid userId)
        {
            var result = _userDal.GetById(userId);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>(UserMessages.UserNotFound);
        }

        public IDataResult<User> GetActiveUserById(Guid userId)
        {
            var result = _userDal.GetOne(u => u.UserId == userId && u.Status == true);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>(UserMessages.UserNotFound);
        }

        public IDataResult<User> GetByUsername(string username)
        {
            var result = _userDal.GetOne(u => u.Username == username);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>();
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.GetOne(u => u.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>();
        }

        public IDataResult<List<Role>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if (result != null)
            {
                return new SuccessDataResult<List<Role>>(result);
            }
            return new ErrorDataResult<List<Role>>();
        }
    }
}
