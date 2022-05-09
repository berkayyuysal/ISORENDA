using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete.FileAuthenticateProcesses
{
    public class FileAuthenticateManager : IFileAuthenticateService
    {
        IFileAuthenticateDal _fileAuthenticateDal;
        public FileAuthenticateManager(IFileAuthenticateDal fileAuthenticateDal)
        {
            _fileAuthenticateDal = fileAuthenticateDal;
        }
        public IResult Add(FileAuthenticate fileAuthenticate)
        {
            _fileAuthenticateDal.Add(fileAuthenticate);
            return new SuccessResult();
        }
        public IResult Update(FileAuthenticate fileAuthenticate)
        {
            _fileAuthenticateDal.Update(fileAuthenticate);
            return new SuccessResult();
        }
        public IResult Delete(FileAuthenticate fileAuthenticate)
        {
            _fileAuthenticateDal.Delete(fileAuthenticate);
            return new SuccessResult();
        }

        public IDataResult<List<FileAuthenticate>> GetBasketCourseMentor()
        {
            var result = _fileAuthenticateDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<FileAuthenticate>>(result);
            }
            return new ErrorDataResult<List<FileAuthenticate>>();
        }

        public IDataResult<FileAuthenticate> GetBasketCourseMentorById(Guid fileAuthenticateId)
        {
            var result = _fileAuthenticateDal.GetById(fileAuthenticateId);
            if (result != null)
            {
                return new SuccessDataResult<FileAuthenticate>(result);
            }
            return new ErrorDataResult<FileAuthenticate>();
        }

        
    }
}
