using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete
{
    class DiscountCourseMentorManager : IDiscountCourseMentorService
    {
        IDiscountCourseMentorDal _discountCourseMentorDal;
        public DiscountCourseMentorManager(IDiscountCourseMentorDal discountCourseMentorDal)
        {
            _discountCourseMentorDal = discountCourseMentorDal;
        }
        public IResult Add(DiscountCourseMentor discountCourseMentor)
        {
            _discountCourseMentorDal.Add(discountCourseMentor);
            return new SuccessResult();
        }
        public IResult Update(DiscountCourseMentor discountCourseMentor)
        {
            _discountCourseMentorDal.Update(discountCourseMentor);
            return new SuccessResult();
        }
        public IResult Delete(DiscountCourseMentor discountCourseMentor)
        {
            _discountCourseMentorDal.Delete(discountCourseMentor);
            return new SuccessResult();
        }

        public IDataResult<List<DiscountCourseMentor>> GetDiscountCourseMentor()
        {
            var result = _discountCourseMentorDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<DiscountCourseMentor>>(result);
            }
            return new ErrorDataResult<List<DiscountCourseMentor>>();
        }

        public IDataResult<DiscountCourseMentor> GetDiscountCourseMentorById(Guid discountCourseMentorId)
        {
            var result = _discountCourseMentorDal.GetById(discountCourseMentorId);
            if (result != null)
            {
                return new SuccessDataResult<DiscountCourseMentor>(result);
            }
            return new ErrorDataResult<DiscountCourseMentor>();
        }

        
    }
}
