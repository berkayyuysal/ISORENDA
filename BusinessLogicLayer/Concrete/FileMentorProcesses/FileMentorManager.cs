using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.FileMentorProcesses
{
    public class FileMentorManager : IFileMentorService
    {
        IFileMentorDal _fileMentorDal;
        public FileMentorManager(IFileMentorDal fileMentorDal)
        {
            _fileMentorDal = fileMentorDal;
        }

        public IResult Add(FileMentor fileMentor)
        {
            _fileMentorDal.Add(fileMentor);
            return new SuccessResult();
        }

        public IResult Update(FileMentor fileMentor)
        {
            _fileMentorDal.Update(fileMentor);
            return new SuccessResult();
        }

        public IResult Delete(FileMentor fileMentor)
        {
            _fileMentorDal.Delete(fileMentor);
            return new SuccessResult();
        }

        public IDataResult<FileMentor> GetFileMentorById(Guid fileMentorId)
        {
            var result = _fileMentorDal.GetById(fileMentorId);
            if (result != null)
            {
                return new SuccessDataResult<FileMentor>(result);
            }
            return new ErrorDataResult<FileMentor>(result);
        }

        public IDataResult<List<FileMentor>> GetFileMentors()
        {
            var result = _fileMentorDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<FileMentor>>(result);
            }
            return new ErrorDataResult<List<FileMentor>>(result);
        }
    }
}
