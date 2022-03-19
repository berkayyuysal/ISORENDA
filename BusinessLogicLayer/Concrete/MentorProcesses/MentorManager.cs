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

namespace BusinessLogicLayer.Concrete.MentorProcesses
{
    public partial class MentorManager : IMentorService
    {
        IMentorDal _mentorDal;
        IUserService _userService;
        IAuthService _authService;
        public MentorManager(IMentorDal mentorDal, IUserService userService, IAuthService authService)
        {
            _mentorDal = mentorDal;
            _userService = userService;
            _authService = authService;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IMentorService.Get")]
        [ValidationAspect(typeof(MentorValidator))]
        public IResult Add(Mentor mentor, UserForRegisterDto userForRegisterDto)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsIdentityNumberExists(mentor.IdentityNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var user = _authService.Register(userForRegisterDto);
            if (!user.IsSuccess)
            {
                return new ErrorResult(user.Message);
            }

            mentor.UserId = user.Data.UserId;
            mentor.User = user.Data;

            _mentorDal.Add(mentor);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IClientService.Get")]
        [ValidationAspect(typeof(MentorValidator))]
        public IResult Update(Mentor mentor)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsIdentityNumberExists(mentor.IdentityNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var updatedUserResult = _userService.Update(mentor.User);
            if (!updatedUserResult.IsSuccess)
            {
                return new ErrorResult(updatedUserResult.Message);
            }
            _mentorDal.Update(mentor);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IClientService.Get")]
        public IResult Delete(Mentor mentor)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsMentorDeleted(mentor));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var userResult = _userService.GetUserById(mentor.UserId);
            if (!userResult.IsSuccess)
            {
                return new ErrorResult(userResult.Message);
            }

            var deletedUserResult = _userService.Delete(userResult.Data);
            if (!deletedUserResult.IsSuccess)
            {
                return new ErrorResult(deletedUserResult.Message);
            }

            return new SuccessResult(mentor.FirstName + " adlı kullanıcı silindi");
        }

        public IDataResult<List<Mentor>> GetMentors()
        {
            var result = _mentorDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Mentor>>(result);
            }
            return new ErrorDataResult<List<Mentor>>();
        }

        public IDataResult<Mentor> GetMentorById(Guid mentorId)
        {
            var result = _mentorDal.GetById(mentorId);
            if (result != null)
            {
                return new SuccessDataResult<Mentor>(result);
            }
            return new ErrorDataResult<Mentor>();
        }

        public IDataResult<Mentor> GetMentorByUserId(Guid userId)
        {
            var user = _userService.GetUserById(userId).Data;
            var result = _mentorDal.GetOne(u => u.UserId == user.UserId);
            if (result != null)
            {
                return new SuccessDataResult<Mentor>(result);
            }
            return new ErrorDataResult<Mentor>();
        }

        public IDataResult<List<Mentor>> GetMentorsWithUserInformations()
        {
            var result = _mentorDal.GetMentorsWithUserInformation();
            if (result != null)
            {
                return new SuccessDataResult<List<Mentor>>(result);
            }
            return new ErrorDataResult<List<Mentor>>();
        }

        public IDataResult<Mentor> GetOneMentorWithUserInformations(Guid mentorId)
        {
            var result = _mentorDal.GetOneMentorWithUserInformations(mentorId);
            if (result != null)
            {
                return new SuccessDataResult<Mentor>(result);
            }
            return new ErrorDataResult<Mentor>();
        }
    }
}
