using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;

namespace BusinessLogicLayer.Concrete
{
    public class FileManager : IFileService
    {
        IFileDal _fileDal;
        public FileManager(IFileDal fileDal)
        {
            _fileDal = fileDal;
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(FileValidator))]
        public IResult Add(File file)
        {
            var result = BusinessRules.Run(CheckIsFileExists(file.Name));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _fileDal.Add(file);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(FileValidator))]
        public IResult Update(File file)
        {
            _fileDal.Update(file);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(FileValidator))]
        public IResult Delete(File file)
        {
            file.Status = false;
            _fileDal.Update(file);
            return new SuccessResult();
        }

        public IDataResult<List<File>> GetFiles()
        {
            var result = _fileDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<File>>(result);
            }
            return new ErrorDataResult<List<File>>("Veri gelemedi");
        }

        public IDataResult<File> GetFileById(Guid fileId)
        {
            var result = _fileDal.GetById(fileId);
            if (result != null)
            {
                return new SuccessDataResult<File>(result);
            }
            return new ErrorDataResult<File>("Veri gelemedi");
        }

        private IResult CheckIsFileExists(string fileName)
        {
            var result = _fileDal.GetOne(f => f.Name==fileName);
            if (result != null)
            {
                return new ErrorResult("Bu isimde bir dosya mevcut.");
            }
            return new SuccessResult();
        }
    }
}
