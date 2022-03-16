using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants.Messages;
using BusinessLogicLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using FluentValidation.Results;

namespace BusinessLogicLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, UserMessages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = userForLoginDto.Email != null ? _userService.GetByMail(userForLoginDto.Email) : _userService.GetByUsername(userForLoginDto.Username);

            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(UserMessages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, UserMessages.SuccessfulLogin);
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = BusinessRules.Run(IsUserMailExists(userForRegisterDto.Email), IsUserUsernameExists(userForRegisterDto.Username));
            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userForRegisterDto.Status,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UpdateUserId = userForRegisterDto.UserId
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, UserMessages.UserRegistered);
        }

        private IResult IsUserMailExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(UserMessages.MailAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult IsUserUsernameExists(string username)
        {
            if (_userService.GetByUsername(username).Data != null)
            {
                return new ErrorResult(UserMessages.UsernameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}