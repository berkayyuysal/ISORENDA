using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Abstract;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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

        public List<User> GetUsers()
        {
            return _userDal.GetAll();
        }

        public void Register(User user)
        {
            _userDal.Add(user);
        }
    }
}
