using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IFileAuthenticateService
    {
        IResult Add(FileAuthenticate fileAuthenticate);
        IResult Update(FileAuthenticate fileAuthenticate);
        IResult Delete(FileAuthenticate fileAuthenticate);
        IDataResult<List<FileAuthenticate>> GetBasketCourseMentor();
        IDataResult<FileAuthenticate> GetBasketCourseMentorById(Guid fileAuthenticateId);
    }
}
