using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface IDiscountCourseMentorService
    {
        IResult Add(DiscountCourseMentor discountCourseMentor);
        IResult Update(DiscountCourseMentor discountCourseMentor);
        IResult Delete(DiscountCourseMentor discountCourseMentor);
        IDataResult<List<DiscountCourseMentor>> GetDiscountCourseMentor();
        IDataResult<DiscountCourseMentor> GetDiscountCourseMentorById(Guid discountCourseMentorId);
    }
}
