using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete.CourseMentorClientProcesses
{
    public class CourseMentorClientManager : ICourseMentorClientService
    {
        ICourseMentorClientDal _courseMentorClientDal;
        public CourseMentorClientManager(ICourseMentorClientDal courseMentorClientDal)
        {
            _courseMentorClientDal = courseMentorClientDal;
        }
        public IResult Add(CourseMentorClient courseMentorClient)
        {
            _courseMentorClientDal.Add(courseMentorClient);
            return new SuccessResult();
        }
        public IResult Update(CourseMentorClient courseMentorClient)
        {
            _courseMentorClientDal.Update(courseMentorClient);
            return new SuccessResult();
        }

        public IResult Delete(CourseMentorClient courseMentorClient)
        {
            _courseMentorClientDal.Delete(courseMentorClient);
            return new SuccessResult();
        }

        public IDataResult<CourseMentorClient> GetCourseMentorClientById(Guid courseMentorClientId)
        {
            var result = _courseMentorClientDal.GetById(courseMentorClientId);
            if (result != null)
            {
                return new SuccessDataResult<CourseMentorClient>(result);
            }
            return new ErrorDataResult<CourseMentorClient>();
        }

        public IDataResult<List<CourseMentorClient>> GetCourseMentorClients()
        {
            var result = _courseMentorClientDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<CourseMentorClient>>(result);
            }
            return new ErrorDataResult<List<CourseMentorClient>>();
        }
    }
}
