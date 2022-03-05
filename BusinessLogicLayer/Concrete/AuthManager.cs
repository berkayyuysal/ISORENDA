using System;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace BusinessLogicLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            // var claims = _userService.GetClaims(user).Data;
            // var accessToken = _tokenHelper.CreateToken(user, claims);
            // return new SuccessDataResult<AccessToken>(accessToken, UserMessages.AccessTokenCreated);
            return new SuccessDataResult<AccessToken>();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
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