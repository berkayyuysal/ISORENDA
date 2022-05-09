using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete.BasketCourseMentorProcesses
{
    public class BasketCourseMentorManager : IBasketCourseMentorService
    {
        IBasketCourseMentorDal _basketCourseMentorDal;
        public BasketCourseMentorManager(IBasketCourseMentorDal basketCourseMentorDal)
        {
            _basketCourseMentorDal = basketCourseMentorDal;
        }
        public IResult Add(BasketCourseMentor basketCourseMentor)
        {
            _basketCourseMentorDal.Add(basketCourseMentor);
            return new SuccessResult();
        }
        public IResult Update(BasketCourseMentor basketCourseMentor)
        {
            _basketCourseMentorDal.Update(basketCourseMentor);
            return new SuccessResult();
        }

        public IResult Delete(BasketCourseMentor basketCourseMentor)
        {
            _basketCourseMentorDal.Delete(basketCourseMentor);
            return new SuccessResult();
        }

        public IDataResult<List<BasketCourseMentor>> GetBasketCourseMentor()
        {
            var result = _basketCourseMentorDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<BasketCourseMentor>>(result);
            }
            return new ErrorDataResult<List<BasketCourseMentor>>();
        }

        public IDataResult<BasketCourseMentor> GetBasketCourseMentorById(Guid basketCourseMentorId)
        {
            var result = _basketCourseMentorDal.GetById(basketCourseMentorId);
            if (result != null)
            {
                return new SuccessDataResult<BasketCourseMentor>(result);
            }
            return new ErrorDataResult<BasketCourseMentor>();
        }
    }
}
