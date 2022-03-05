using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Abstract
{
    public interface IUserService 
    {
        public IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        public IDataResult<List<User>> GetUsers();
        IDataResult<List<Role>> GetClaims(User user);
    }
}
