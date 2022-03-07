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
        
        //[SecuredOperation("admin")] -> OK
        //[ValidationAspect(typeof(StudentValidator))] //-> OK
        //[CacheAspect(5)] -> OK Parameter is optional. If you dont send any parameter the parameter value setted "60" by default.
        //[CacheRemoveAspect("IStudentService.Get")] // -> OK
        //[TransactionScopeAspect] -> OK
        //[PerformanceAspect(5)] -> OK
        //[LogAspect(typeof(FileLogger))] -> OK
        public IDataResult<List<User>> GetUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Kullanıcılar Geldi.");
        }
        
        public IDataResult<User> GetByUsername(string username)
        {
             return new SuccessDataResult<User>(_userDal.GetOne(u => u.Username == username));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.GetOne(u => u.Email == email));
        }

        public IDataResult<List<Role>> GetClaims(User user)
        {
            return new SuccessDataResult<List<Role>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetUserById(Guid id)
        {
            var user = _userDal.GetById(id);
            if (user == null)
            {
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            }
            return new SuccessDataResult<User>(_userDal.GetById(id));
        }

    }
}
