using System;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

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
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(UserMessages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, UserMessages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = BusinessRules.Run(UserExists(userForRegisterDto.Email));
            if (result != null)
            {
                return new ErrorDataResult<User>(UserMessages.UserAlreadyExists);
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
                UpdateUserId = userForRegisterDto.UpdateUserId
            };
            _userService.Add(user);

            return new SuccessDataResult<User>(user, UserMessages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(UserMessages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}