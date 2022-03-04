using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Abstract
{
    public interface IUserService 
    {
        public void Register(User user);
        public List<User> GetUsers();
    }
}
