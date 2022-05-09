using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface ICourseMentorClientService
    {
        IResult Add(CourseMentorClient courseMentorClient);
        IResult Update(CourseMentorClient courseMentorClient);
        IResult Delete(CourseMentorClient courseMentorClient);
        IDataResult<List<CourseMentorClient>> GetCourseMentorClients();
        IDataResult<CourseMentorClient> GetCourseMentorClientById(Guid courseMentorClientId);
    }
}
