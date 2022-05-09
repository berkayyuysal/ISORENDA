using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.FileClientProcesses
{
    public class FileClientManager : IFileClientService
    {
        IFileClientDal _fileClientDal;
        public FileClientManager(IFileClientDal fileClientDal)
        {
            _fileClientDal = fileClientDal;
        }

        public IResult Add(FileClient fileClient)
        {
            _fileClientDal.Add(fileClient);
            return new SuccessResult();
        }

        public IResult Update(FileClient fileClient)
        {
            _fileClientDal.Update(fileClient);
            return new SuccessResult();
        }

        public IResult Delete(FileClient fileClient)
        {
            _fileClientDal.Delete(fileClient);
            return new SuccessResult();
        }

        public IDataResult<FileClient> GetFileClientById(Guid fileClientId)
        {
            var result = _fileClientDal.GetById(fileClientId);
            if (result != null)
            {
                return new SuccessDataResult<FileClient>(result);
            }
            return new ErrorDataResult<FileClient>(result);
        }

        public IDataResult<List<FileClient>> GetFileClients()
        {
            var result = _fileClientDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<FileClient>>(result);
            }
            return new ErrorDataResult<List<FileClient>>(result);
        }
    }
}
