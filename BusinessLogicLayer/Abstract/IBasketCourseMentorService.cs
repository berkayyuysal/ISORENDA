using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IBasketCourseMentorService
    {
        IResult Add(BasketCourseMentor basketCourseMentor);
        IResult Update(BasketCourseMentor basketCourseMentor);
        IResult Delete(BasketCourseMentor basketCourseMentor);
        IDataResult<List<BasketCourseMentor>> GetBasketCourseMentor();
        IDataResult<BasketCourseMentor> GetBasketCourseMentorById(Guid basketCourseMentorId);
    }
}
