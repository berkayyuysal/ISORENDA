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
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetUsers();
        IDataResult<User> GetUserById(Guid userId);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetByUsername(string username);
        IDataResult<List<Role>> GetClaims(User user);
    }
}
