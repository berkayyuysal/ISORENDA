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
        IDataResult<User> GetByUsername(string username);
        public IDataResult<List<User>> GetUsers();
        IDataResult<List<Role>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetUserById(Guid id);
    }
}
