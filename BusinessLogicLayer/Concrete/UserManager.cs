using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants.Messages;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            user.Status = false;
            _userDal.Update(user);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")] -> OK
        //[ValidationAspect(typeof(StudentValidator))] //-> OK
        //[CacheAspect(5)] -> OK Parameter is optional. If you dont send any parameter the parameter value setted "60" by default.
        //[CacheRemoveAspect("IStudentService.Get")] // -> OK
        //[TransactionScopeAspect] -> OK
        //[PerformanceAspect(5)] -> OK
        //[LogAspect(typeof(FileLogger))] -> OK
        public IDataResult<List<User>> GetUsers()
        {
            var result = _userDal.GetAll();
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
